using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    private Vector3 startposition;
    // Start is called before the first frame update
    void Start()
    {
         startposition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (temperature.hotvalue>= 10)
        {
            transform.position=startposition;
            temperature.hotvalue = 0;
        }
        if (temperature.coldvalue >= 10)
        {
            transform.position = startposition;
            temperature.coldvalue = 0;
        }
    }
}
