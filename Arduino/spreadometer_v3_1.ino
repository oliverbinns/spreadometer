//Spreadometer controls v3.1 
//Oliver Binns 2014

//This code is inteded to be loaded onto an Arduino-based spread-o-meter control board v3 and above
//The code requries a connection to the spread-o-meter control program on a PC
//Requires capacitive sensor library v4 on compile (arduino.cc/capcitive)


//Start by defining objects and associated variables

//Define object for servo motor
#include <Servo.h>
Servo myServo;

//Define variables for needle movement
int del=50;
int newVal = 0;
int angle = 0;
int minVal = 200;
int maxVal = 300;
int minAngle = 46;
int maxAngle = 146;

//Define variables for request button threshold and request status monitoring
int capacThresh = 1000;
int req=0;

//Define pin settings
const int greenPin=9;                 //Tri-colour LED green pin
const int bluePin=10;                 //Tri-colour LED blue pin
const int redPin=11;                  //Tri-colour LED red pin
const int requestPin1=4;              //Request button pin 1
const int requestPin2=2;              //Request button pin 2
const int servoPin=6;                 //Servo motor pin

//Define object for capacitive request button and assign pins
#include <CapacitiveSensor.h>
CapacitiveSensor capSensor = CapacitiveSensor(requestPin1,requestPin2); 



//Setup routine
void setup() {    
  //Set-up serial communications
  Serial.begin(9600);
  Serial.print("Spread-o-meter v2.0 \n");
  Serial.print("Initialising hardware \n");
  
  //Set up LED pins
  pinMode(greenPin,OUTPUT);
  pinMode(redPin,OUTPUT);
  pinMode(bluePin,OUTPUT);

  //Set the initial LED colour (orange)
  digitalWrite(redPin,HIGH);
  digitalWrite(greenPin,HIGH);
  
  //Set the servo pin to the servo object
  myServo.attach(servoPin);    

  //Check the servo by running through the range
  myServo.write(180-minAngle);
  delay(1000);
  myServo.write(180-maxAngle);
  delay(1000);
  myServo.write(180-minAngle);
  
  //Indicate to the spread-o-meter control that the system is ready
  Serial.print("Standing by for input... \n");

  //Set the LED to the ready state (blue)
  digitalWrite(redPin,LOW);
  digitalWrite(greenPin,LOW);
  digitalWrite(bluePin,HIGH);

}



// Main program routine, which loops until the system is powered down:
void loop() {  
  
  //Parse any incoming serial messages from the PC
  if (Serial.available() > 0) {
    //Reset the request state to false
    req=0;
    
    // Read the incoming data 
    // Expecting three integers separated by commas then newline: value,min,max\n
    newVal = Serial.parseInt();
    minVal = Serial.parseInt();
    maxVal = Serial.parseInt();

    //When the new line command is received, process the values
    if (Serial.read() == '\n') {
      if (newVal==-1 && minVal == -1){
        //Ping request sent by control software - send response
        Serial.print("PING-SPREADOMETER-");
        Serial.print(maxVal);
        Serial.print('\n');
      } 
      else {
        //Update request
      
        //Calculate angle
        angle = map(newVal, minVal, maxVal, minAngle, maxAngle);
  
        //Send a confirmation reply to the PC with the value and angle
        Serial.print("Gauge set: ");
        Serial.print("Spread: ");
        Serial.print(newVal);
        Serial.print(", ");
        Serial.print("Angle: ");
        Serial.print(angle);
        Serial.print('\n');
  
        //Deal with error values (over-range)
        if(newVal < minVal || newVal > maxVal){
          //Set the servo to zero angle
          myServo.write(180-minAngle);
          
          //Send an error message reply to the PC
          Serial.print("ERROR - value outside range");
          Serial.print('\n');
  
          //Set the LED to red
          digitalWrite(redPin,HIGH);
          digitalWrite(greenPin,LOW);
          digitalWrite(bluePin,LOW);
  
        } 
        else {
          //Set the servo
          myServo.write(180-angle);
          
          //Set the LED to green
          digitalWrite(redPin,LOW);
          digitalWrite(greenPin,HIGH);
          digitalWrite(bluePin,LOW);
        }
      }
    }
  }
  
  //Check to see if the request button has been pressed
  long sensorValue = capSensor.capacitiveSensor(30);
  if(sensorValue > capacThresh && req==0){
        //Set the sero to the minumumum angle
        myServo.write(180-minAngle);

        //Set the LED to blue
        digitalWrite(redPin,LOW);
        digitalWrite(greenPin,LOW);
        digitalWrite(bluePin,HIGH);
   
        //Send a request message to the PC
        Serial.print("User requesting update");
        Serial.print('\n');
        
        //Set the request state to true until the system responds (prevents multiple requests)
        req=1;
  } 
  
    
}




