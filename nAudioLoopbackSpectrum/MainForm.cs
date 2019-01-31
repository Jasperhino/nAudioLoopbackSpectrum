using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.IO.Ports;


namespace nAudioLoopbackSpectrum
{
    public partial class MainForm : Form
    {

        // SOUNDCARD ANALYSIS SETTINGS
        private int RATE = 48000; // sample rate of the sound card
        private int BUFFERSIZE = (int)Math.Pow(2, 13); // must be a multiple of 2 // 4096

        // prepare class objects
        public BufferedWaveProvider bwp;

        public MainForm()
        {
            InitializeComponent();
            SetupGraphLabels();
            SetupSerialPort();
            StartLoopbackCapture();
            timerReplot.Enabled = true;
        }

        void SetupSerialPort()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox.DataSource = ports;
        }

        void AudioDataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
            calculateLatestData();
        }

        public void SetupGraphLabels()
        {
            scottPlotUC2.fig.labelTitle = "FFT Data";
            scottPlotUC2.fig.labelY = "Power (raw)";
            scottPlotUC2.fig.labelX = "Frequency (Hz)";
        }

        private void Form1_Load(object sender, EventArgs e){}

        private void StartLoopbackCapture()
        {
            var capture = new WasapiLoopbackCapture();
            
            capture.DataAvailable += new EventHandler<WaveInEventArgs>(AudioDataAvailable);
            
            bwp = new BufferedWaveProvider(capture.WaveFormat);
            bwp.BufferLength = BUFFERSIZE * 2;
            bwp.DiscardOnBufferOverflow = true;

            try
            {
                capture.StartRecording();
            }
            catch
            {
                string msg = "Could not record from audio device!\n\n";
                msg += "Is it set as your default recording device?";
                MessageBox.Show(msg, "ERROR");
            }
        }
        Boolean sendNext = true;
    
        private void Timer_Tick(object sender, EventArgs e)
        {
            // turn off the timer, take as long as we need to plot, then turn the timer back on
            timerReplot.Enabled = false;
            if (checkBoxFTT.Checked)
            {
                PlotLatestData();
            }
            if (cb_led_fft.Checked && sendNext)
            {
                sendNext = false;
                SerialSend();
            }
            timerReplot.Enabled = true;
        }

        public int numberOfDraws = 0;
        public bool needsAutoScaling = true;

        double[] bands = new double[32];
        int graphPointCount = 0;

        public void calculateLatestData()
        {
            // check the incoming microphone audio
            int frameSize = BUFFERSIZE;
            var audioBytes = new byte[frameSize];
            bwp.Read(audioBytes, 0, frameSize);

            // return if there's nothing new to plot
            if (audioBytes.Length == 0)
                return;
            if (audioBytes[frameSize - 2] == 0)
                return;

            // incoming data is 16-bit (2 bytes per audio point)
            int BYTES_PER_POINT = 2;

            // create a (32-bit) int array ready to fill with the 16-bit data
            graphPointCount = audioBytes.Length / BYTES_PER_POINT;

            // create double arrays to hold the data we will graph
            double[] pcm = new double[graphPointCount];
            double[] fft = new double[graphPointCount];
            double[] fftReal = new double[graphPointCount / 2];

            // populate Xs and Ys with double data
            for (int i = 0; i < graphPointCount; i++)
            {
                // read the int16 from the two bytes
                Int16 val = BitConverter.ToInt16(audioBytes, i * 2);

                // store the value in Ys as a percent (+/- 100% = 200%)
                pcm[i] = (double)val / Math.Pow(2, 16) * 10.0;
            }

            // calculate the full FFT
            fft = FFT(pcm);

            // just keep the real half (the other half imaginary)
            Array.Copy(fft, fftReal, fftReal.Length);
            // calculate logarithmic interpolated values
            
            Array.Copy(fftReal, bands, bands.Length);
        }

        public void PlotLatestData()
        {
            // determine horizontal axis units for graphs
            double pcmPointSpacingMs = RATE / 1000;
            double fftMaxFreq = RATE / 2;
            double fftPointSpacingHz = fftMaxFreq / graphPointCount;
            // plot the Xs and Ys for both graphs
            //scottPlotUC1.Clear();

            //scottPlotUC1.PlotSignal(pcm, pcmPointSpacingMs, Color.Blue);
            scottPlotUC2.Clear();
            scottPlotUC2.PlotSignal(bands, fftPointSpacingHz, Color.Blue);
            //scottPlotUC2.PlotSignal(fftRealLog, fftPointSpacingHz, Color.Orange);


            // optionally adjust the scale to automatically fit the data
            if (needsAutoScaling)
            {
                scottPlotUC2.AxisAuto();
                needsAutoScaling = false;
            }

            numberOfDraws += 1;
            lblStatus.Text = $"Analyzed and graphed PCM and FFT data {numberOfDraws} times";

            // this reduces flicker and helps keep the program responsive
            //Application.DoEvents();
        }

        private void autoScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needsAutoScaling = true;
        }

        private void infoMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg += "left-click-drag to pan\n";
            msg += "right-click-drag to zoom\n";
            msg += "middle-click to auto-axis\n";
            msg += "double-click for graphing stats\n";
            MessageBox.Show(msg);
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/swharden/Csharp-Data-Visualization");
        }


        public double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            
            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
                fft[i] = fftComplex[i].Magnitude;
            return fft;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex > -1)
            {
                Connect(comboBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a port first");
            }
        }

        SerialPort port;
        bool connected = false;
        void Connect(String portName)
        {
            port = new SerialPort(portName);
            if (!connected && !port.IsOpen)
            {
                port.BaudRate = 115200;
                try
                {
                    connected = true;
                    port.Open();
                    port.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
                    port.ErrorReceived += new SerialErrorReceivedEventHandler(OnSerialError);

                    MessageBox.Show(String.Format("Connected to port '{0}'", portName));
                } catch (UnauthorizedAccessException e)
                {
                    connected = false;
                    MessageBox.Show("Port is busy!\n '{0}'", e.Message);
                }

            }
        }

        void SerialSend()
        {
            if (connected && port.IsOpen)
            {
                byte[] ledmatrix = new byte[32*8 +1];
                
                for (int i = 0; i < bands.Length; i++)
                {
                    int intensity = (int)(bands[i] * 2048.0);
                    for (int j = 7; j >= 0; j--)
                    {
                        
                        byte b = 255;
                        if (intensity < 255)
                            b = (byte) intensity;
                        if (intensity < 0)
                            b = 0;
                        ledmatrix[32 * j + i + 1] = b; // Bsp 1000/2048
                        intensity -= b;
                    }
                }
                ledmatrix[0]= 0xAA; // sync byte

                /*for (int i = 1; i< ledmatrix.Length; i++)
                {
                    Console.Write("{0:X}", ledmatrix[i]);
                    if (i % 32 == 0) Console.WriteLine();
                }*/
                port.Write(ledmatrix, 0, ledmatrix.Length);
            }
        }

        void SerialPrint()
        {
            if (connected && port.IsOpen)
            {
                byte[] printbyte = { 0x70 }; // p for print
                Console.WriteLine("Sending Printbyte");
                port.Write(printbyte, 0, printbyte.Length);
            }
        }

        void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            sendNext = true;
            if (port.ReadExisting().Equals("finished"))
            {
                sendNext = true;
            }
            Console.Write(port.ReadExisting());
        }

        void OnSerialError(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            connected = false;
            port.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SerialSend();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            SerialPrint();
        }
    }
}