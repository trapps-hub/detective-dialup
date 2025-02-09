using UnityEngine;
using System.IO.Ports;
using NUnit.Framework.Constraints;

public class SerialRead : MonoBehaviour
{
    private SerialPort serialPort;
    public string portName = "COM3";  // Default serial port (on Linux-based systems like Raspberry Pi)
    public int baudRate = 115200;  // Baud rate, change as per your device's setting
    public bool isConnected = false;

    void Start()
    {
        // Try to open the serial port
        OpenSerialPort();
        serialPort.Write("z");
    }

    void Update()
    {
        // Continuously check for incoming data from the serial port
        if (isConnected)
        {
            
            if (serialPort.BytesToRead > 0)
            {
                int message = serialPort.ReadByte();  // Read a line of data from the serial port
                print("Received message: " + message);  // Output the message to the Unity console
            }
        }
    }

    void OpenSerialPort()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);  // Initialize the SerialPort with port and baud rate
            
            serialPort.DtrEnable = true;
            
            serialPort.Open();  // Open the serial port
            serialPort.ReadTimeout = 5000;  // Set the timeout for reading
            isConnected = serialPort.IsOpen;
            if (isConnected) {
                Debug.Log("Serial port opened successfully.");
            } else {
                Debug.Log("Serial port not opened not successfully.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    void OnApplicationQuit()
    {
        // Close the serial port when the application quits
        if (isConnected)
        {
            serialPort.Close();
            Debug.Log("Serial port closed.");
        }
    }
}

