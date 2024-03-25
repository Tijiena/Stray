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
        Debug.Log(button1);

        x = float.Parse(newStrings[0]);
        y = float.Parse(newStrings[1]);
        z = float.Parse(newStrings[2]);
        button1 = int.Parse(newStrings[3]);
        button2 = int.Parse(newStrings[4]);

    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
    void Update()
        {
            if (z<155 && z>20 )
            {
                battery.transform.position = new Vector3(battery.transform.position.x, battery.transform.position.y - 0.5f * Time.deltaTime, battery.transform.position.z);
                Debug.Log("Down");
            }
            if (y>20)
            {
                battery.transform.position = new Vector3(battery.transform.position.x + 0.5f * Time.deltaTime, battery.transform.position.y, battery.transform.position.z);
                Debug.Log("Left");
            }
            if (y <-20)
            {
                battery.transform.position = new Vector3(battery.transform.position.x - 0.5f * Time.deltaTime, battery.transform.position.y, battery.transform.position.z);
                Debug.Log("Right");
            }
            if (z >= -155 && z<20)
            {
                battery.transform.position = new Vector3(battery.transform.position.x - 0.5f * Time.deltaTime, battery.transform.position.y, battery.transform.position.z);
                Debug.Log("Up");
            }
            if (button1 == 1)
            {
                Debug.Log("button1");
                if (temperature.hotvalue > 0)
                {
                    temperature.hotvalue = temperature.hotvalue -0.5f;
                }
                if (temperature.hotvalue<= 0)
                {
                    temperature.coldvalue = temperature.coldvalue + 0.5f;
                }
            }
            if (button2 == 1)
            {
                Debug.Log("button2");
                if (temperature.coldvalue<=0)
                {
                    temperature.hotvalue = temperature.hotvalue + 0.5f;
                }
                if (temperature.coldvalue > 0)
                {
                    temperature.coldvalue = temperature.coldvalue - 0.5f;
                }
            }
        }
        // Debug.Log(gameManager.currentPlush);
    }


