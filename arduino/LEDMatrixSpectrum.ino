#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>

#define PIN 11

Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 8, PIN,
  NEO_MATRIX_TOP     + NEO_MATRIX_LEFT +
  NEO_MATRIX_ROWS + NEO_MATRIX_ZIGZAG,
  NEO_RGB            + NEO_KHZ800);
  
const int rows = 8;
const int columns = 32;
const int array_size = 256;
byte vals [array_size];

void resetArray(){
  for (int i = 0; i < array_size; i++){
    vals[i] = 1;
  }
}

void printArray(){
  for (int i = 0; i < array_size; i++){
    Serial.print(vals[i]);
  }
}
void print2DArray( const byte a[][ columns ] ) {
   // loop through array's rows
   for ( int i = 0; i < rows; ++i ) {
      // loop through columns of current row
      for ( int j = 0; j < columns; ++j ){
        Serial.print (a[ i ][ j ] , HEX);
        Serial.print(";");
      }
      Serial.println() ; // start new line of output
   } 
// end outer for
}

void setup() {
  // initialize serial port
  Serial.begin(115200);
  vals[0] = 128;
  matrix.begin();
  displayFFT();
}

void loop() {
  readSerial2();
}


int index = 0;
bool reading = false;

void readSerial2(){
    while(!Serial.available());
     if(reading){
      while(index < array_size && Serial.available()){
        vals[index++] = Serial.read();
      }
      if(index >= array_size){
        displayFFT();
        reading = false;
        Serial.print("finished");
      }
     }
     else{
       byte b = Serial.read();
    
       if(b == 0xAA){
        index = 0;
        reading = true;
       } else if (b == 0x70){
        Serial.println("recieved print cmd");
        printArray();
       } else if (b == 0x72){
        Serial.println("recieved clear cmd");
        resetArray();
       }
     }
}

void displayFFT() {
  matrix.fillScreen(0);
  byte r = 0;
  byte g = 0;
  byte b = 0;
  for(byte r = 0; r < rows; r++){
    for(byte c = 0; c < columns; c++){
      byte i = vals[columns*r+c];
      matrix.drawPixel(c, r, matrix.Color(i, 0, i));
    }
  }
  matrix.show();
}
