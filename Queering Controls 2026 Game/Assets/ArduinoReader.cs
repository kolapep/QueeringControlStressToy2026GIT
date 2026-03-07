using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoReader : MonoBehaviour
{
    private SerialPort serialPort;

    public int pressureUp;
    public int pressureDown;
    public int pressureLeft;
    public int pressureRight;
    public int flex;

    void Start()
    {
        string portName = "/dev/cu.usbmodem101"; // 你的端口
        try
        {
            serialPort = new SerialPort(portName, 9600);
            serialPort.ReadTimeout = 50;
            serialPort.Open();
            Debug.Log("Serial Port Opened");
        }
        catch (Exception e)
        {
            Debug.LogError("Serial Port Error: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();

                string[] values = data.Split(',');

                if (values.Length == 5)
                {
                    int.TryParse(values[0], out pressureUp);
                    int.TryParse(values[1], out pressureDown);
                    int.TryParse(values[2], out pressureLeft);
                    int.TryParse(values[3], out pressureRight);
                    int.TryParse(values[4], out flex);

                    Debug.Log($"U:{pressureUp} D:{pressureDown} L:{pressureLeft} R:{pressureRight} F:{flex}");
                }
            }
            catch (Exception)
            {
                // ignore errors
            }
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
