using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    float randNum;
    float randSpeed;
    Rigidbody rb;
    

    private void Start()
    {
        //Randomize speed and rotation speed
        rb = GetComponent<Rigidbody>();
        randNum = Random.Range(0, 30);
        randSpeed = Random.Range(6, 12);
    }
    void Update()
    {
        //Set forward velocity at random speed
        rb.velocity = transform.forward * randSpeed;

        //Random rotation of asteroid
        transform.Rotate(new Vector3(0, 0, randNum * Time.deltaTime), Space.World);
    }
}
