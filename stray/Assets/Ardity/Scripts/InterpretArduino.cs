using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class InterpretArduinoS : MonoBehaviour
{

    public SerialController serialController;
    public float x, y, z;
    public int button1, button2;
    public GameObject battery;
   
    void OnMessageArrived(string msg)
    {
        string[] newStrings = msg.Split(',');
        Debug.Log(x);

        x = float.Parse(newStrings[0]);
        y = float.Parse(newStrings[1]);
        z = float.Parse(newStrings[2]);
       button1 = int.Parse(newStrings[3]);
       button2= int.Parse(newStrings[4]);

        if (x >= 50 && x <= 235)
        {
            battery.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f * Time.deltaTime, transform.position.z);
            Debug.Log("Down");
        }
        if (y>= 2 && y <= 40)
        {
            battery.transform.position = new Vector3(transform.position.x + 0.5f * Time.deltaTime, transform.position.y, transform.position.z);
            Debug.Log("Left");
        }
        if (y >= -25 && y<= 2)
        {
            battery.transform.position = new Vector3(transform.position.x - 0.5f * Time.deltaTime, transform.position.y, transform.position.z);
            Debug.Log("Right");
        }
        if (z >= -170 && z <= 150)
        {
            battery.transform.position = new Vector3(transform.position.x - 0.5f * Time.deltaTime, transform.position.y, transform.position.z);
            Debug.Log("Up");
        }



        // Debug.Log(gameManager.currentPlush);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
