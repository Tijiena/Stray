using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionKey : MonoBehaviour
{
    
    public GameObject instructionPanel;
    void Start()
    {
        instructionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Q)){
        instructionPanel.SetActive(true);
       }
    }
    public void InstructionPanelButton(){
        instructionPanel.SetActive(true);
        Debug.Log("ButtonClicked");
    }

    public void InstrctionClose(){
        instructionPanel.SetActive(false);
    }
}
