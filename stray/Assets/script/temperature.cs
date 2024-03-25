using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vignette = UnityEngine.Rendering.PostProcessing.Vignette;

public class temperature : MonoBehaviour
{
   
    public float weightValue = 0.0f; // Lower camel case for variable names
    
   
    public Slider HotSlider;
    public Slider ColdSlider;
    public int colliderNumber;
    public static float hotvalue, coldvalue;
    [SerializeField]
    public GameObject posteffect;
    private Vignette vignette;
    public Volume vol;
    // Start is called before the first frame update
    void Start()
    {
        
        HotSlider.maxValue = 10;
        ColdSlider.maxValue = 10;
        hotvalue = 0;
        coldvalue = 0;
       
    }
    private void Update()
    {
        HotSlider.value = hotvalue;
        ColdSlider.value = coldvalue;
        Debug.Log(hotvalue);
    }
    // OnTriggerStay is called every frame while a GameObject with a collider is within the trigger
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("cat"))
        {   if(coldvalue >0)
            {
                coldvalue =coldvalue-0.05f;
            }
            if(coldvalue <=0)
            {
                hotvalue=hotvalue+0.05f;
            }
          
            Debug.Log("EnterTrigger/Stay");
            weightValue += 0.1f;

            if (vignette != null)
            {
                vignette.intensity.value = 0.5f;
            }
        }
        else
        {
            hotvalue=hotvalue-0.05f/colliderNumber;
            if (hotvalue <= 0)
            {
               coldvalue=coldvalue+0.05f/colliderNumber;
            }
        }
    }
   
}
