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
    public Slider tem_slider;
    public Volume vol;
    public GameObject posteffect;
    public float WeightValue;
    public Vignette _vg;


    // Start is called before the first frame update
    void Start()
    {
        vol = posteffect.GetComponent<Volume>();
        vol.weight = 0f;
        


    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "cat")
        {
            vol.weight=vol.weight+0.1f;
        }
    }
   
}
