using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float X;
    public float Z;
    private float xx, zz;

    private Vector3 moveDirection;
    private void Start()
    {
        X = 5f;
    }
    void Update()
    {
        moveDirection = new Vector3(X, 0f, 0f);
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        X = -X;
        Z = -Z;
    }
}
