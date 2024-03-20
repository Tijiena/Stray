using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject prefab;
    public List<GameObject> pulledobjects;
    public int countToPull = 20;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        pulledobjects = new List<GameObject>();
        for(int i = 0; i < countToPull; i++)
        {
            GameObject obj= Instantiate(prefab);
            obj.SetActive(false);
            pulledobjects.Add(obj);
        }
    }
}
