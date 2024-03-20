using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;

    [Header("Private Varibles")]
    private Vector3 startPoint;
    private const float raduis = 1F;

    private float time;
    // Start is called before the first frame update

    private void Start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        startPoint = transform.position;
        
        time += Time.deltaTime;
        if (time > 1f)
        {
            SpawnProjectile(numberOfProjectiles);
            time -= 1f;
        }
    }

    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;
        for(int i = 0; i <= _numberOfProjectiles-1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * raduis;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * raduis;
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection=(projectileVector - startPoint).normalized*projectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);
            angle += angleStep;
        }
        
    }
 
}

