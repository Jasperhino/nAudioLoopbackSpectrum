namespace nAudioLoopbackSpectrum
{
    partial class MainForm
    {
       /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scottPlotUC2 = new ScottPlot.ScottPlotUC();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.timerReplot = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_connect = new System.Windows.Forms.Button();
            this.checkBoxFTT = new System.Windows.Forms.CheckBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_led_fft = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.scottPlotUC2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(939, 765);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // scottPlotUC2
            // 
            this.scottPlotUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scottPlotUC2.Location = new System.Drawing.Point(2, 384);
            this.scottPlotUC2.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC2.Name = "scottPlotUC2";
            this.scottPlotUC2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.scottPlotUC2.Size = new System.Drawing.Size(935, 358);
            this.scottPlotUC2.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(3, 358);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 2;
            this.comboBox.Text = "SerialPort";
            // 
            // timerReplot
            // 
            this.timerReplot.Interval = 1;
            this.timerReplot.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 743);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(939, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(154, 17);
            this.lblStatus.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoScaleToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // autoScaleToolStripMenuItem
            // 
            this.autoScaleToolStripMenuItem.Name = "autoScaleToolStripMenuItem";
            this.autoScaleToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.autoScaleToolStripMenuItem.Text = "Auto-Scale";
            this.autoScaleToolStripMenuItem.Click += new System.EventHandler(this.autoScaleToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem,
            this.infoMessageToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // infoMessageToolStripMenuItem
            // 
            this.infoMessageToolStripMenuItem.Name = "infoMessageToolStripMenuItem";
            this.infoMessageToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.infoMessageToolStripMenuItem.Text = "Info Message";
            this.infoMessageToolStripMenuItem.Click += new System.EventHandler(this.infoMessageToolStripMenuItem_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(130, 358);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(95, 22);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // checkBoxFTT
            // 
            this.checkBoxFTT.AutoSize = true;
            this.checkBoxFTT.Location = new System.Drawing.Point(859, 361);
            this.checkBoxFTT.Name = "checkBoxFTT";
            this.checkBoxFTT.Size = new System.Drawing.Size(78, 17);
            this.checkBoxFTT.TabIndex = 4;
            this.checkBoxFTT.Text = "render FFT";
            this.checkBoxFTT.UseVisualStyleBackColor = true;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(231, 359);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(95, 22);
            this.btn_disconnect.TabIndex = 5;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(332, 359);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(95, 22);
            this.btn_send.TabIndex = 6;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // cb_led_fft
            // 
            this.cb_led_fft.AutoSize = true;
            this.cb_led_fft.Location = new System.Drawing.Point(775, 361);
            this.cb_led_fft.Name = "cb_led_fft";
            this.cb_led_fft.Size = new System.Drawing.Size(62, 17);
            this.cb_led_fft.TabIndex = 8;
            this.cb_led_fft.Text = "led FFT";
            this.cb_led_fft.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 765);
            this.Controls.Add(this.cb_led_fft);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.checkBoxFTT);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ScottPlot Microphone FFT Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.ScottPlotUC scottPlotUC2;
        private System.Windows.Forms.Timer timerReplot;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoMessageToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.CheckBox checkBoxFTT;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cb_led_fft;
    }
}