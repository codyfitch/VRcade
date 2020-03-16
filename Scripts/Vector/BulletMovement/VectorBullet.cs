using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorBullet : MonoBehaviour
{
    float randNum;
    float randSpeed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        randNum = Random.Range(0, 30);
        randSpeed = Random.Range(12, 24);
    }
    void Update()
    {
        rb.velocity = -transform.forward * randSpeed; //Bullet moves forward at random speed
        transform.Rotate(new Vector3(0, 0, randNum * Time.deltaTime), Space.World); //Bullets randomly rotate
    }
}
