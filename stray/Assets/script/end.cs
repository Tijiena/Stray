using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class end : MonoBehaviour
{
    public string ObjectTag;
    public string SceneName;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag==ObjectTag)
        {
            SceneManager.LoadScene(SceneName);
        }
    }


}
