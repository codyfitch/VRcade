using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid3Controller : MonoBehaviour
{
    float randNum;
    float randAxis;
    float randSpeed;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        randNum = Random.Range(0, 30);
        randAxis = Random.Range(1, 10);
        randSpeed = Random.Range(6, 12);
    }
    void Update()
    {
        rb.velocity = -transform.right * randSpeed;
        //transform.Rotate(new Vector3(0, 0, randNum * Time.deltaTime), Space.World);
    }
}
