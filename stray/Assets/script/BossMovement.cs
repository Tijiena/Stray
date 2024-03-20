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
        X = Random.Range(minX, maxX);
        Z = Random.Range(minZ, maxZ);
    }
    void Update()
    {
        moveDirection = new Vector3(X, 0f, Z);
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        xx= Random.Range(-2, 2);
        zz = Random.Range(-2, 2);
        X = -X+xx;
        Z = -Z+zz;
    }
}
