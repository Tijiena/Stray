using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class InterpretArduinoS : MonoBehaviour
{

    public SerialController serialController;
    public float x, y, z;
    public int button1, button2;
   
    void OnMessageArrived(string msg)
    {
        string[] newStrings = msg.Split(',');
        Debug.Log(x);

        x = float.Parse(newStrings[0]);
        y = float.Parse(newStrings[1]);
        z = float.Parse(newStrings[2]);
       button1 = int.Parse(newStrings[3]);
       button2= int.Parse(newStrings[4]);
        

        // Debug.Log(gameManager.currentPlush);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
