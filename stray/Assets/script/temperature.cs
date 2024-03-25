using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vignette = UnityEngine.Rendering.PostProcessing.Vignette;

public class temperature : MonoBehaviour
{
   public GameObject posteffect;
    public float weightValue = 0.0f; // Lower camel case for variable names
    private PostProcessVolume postProcessVolume;
    private Vignette vignette;
    public Slider HotSlider;
    public Slider ColdSlider;
    // Start is called before the first frame update
    void Start()
    {
        HotSlider.maxValue = 20;
        ColdSlider.maxValue = 20;
        HotSlider.value = 0;
        ColdSlider.value = 0;
        postProcessVolume = posteffect.GetComponent<PostProcessVolume>();

        // Check if postProcessVolume is null before trying to access its profile
        if (postProcessVolume != null && postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = 0f; // Initialize intensity to 0
        }
    }
    private void Update()
    {
        
    }
    // OnTriggerStay is called every frame while a GameObject with a collider is within the trigger
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("cat"))
        {   if(ColdSlider.value >0)
            {
                ColdSlider.value=ColdSlider.value-0.05f;
            }
            if(ColdSlider.value <=0)
            {
                HotSlider.value=HotSlider.value+0.05f;
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
            HotSlider.value=HotSlider.value-0.05f;
            if (HotSlider.value <= 0)
            {
                ColdSlider.value=ColdSlider.value+0.05f;
            }
        }
    }
   
}
