using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int randNum;
    private int randSpeed;
    bool forward = false;
    bool backward = false;
    bool left = false;
    bool right = false;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetNumber();
    }

    void GetNumber()
    {
        randNum = Random.Range(0, 24);
        randSpeed = Random.Range(0, 5);
        SetDirection();
    }

    //Take number from random number generator and determine movement based on that number
    void SetDirection()
    {
        //Forward
        if(randNum <= 4 && randNum < 8)
        {
            forward = true;
            backward = false;
            left = false;
            right = false;
        }
        //Backward
        else if(randNum >= 8 && randNum < 12)
        {
            forward = false;
            backward = true;
            left = false;
            right = false;
        }
        //Left
        else if(randNum >= 12 && randNum < 16)
        {
            forward = false;
            backward = false;
            left = true;
            right = false;
        }
        //Right
        else if(randNum >= 16 && randNum < 24)
        {
            forward = false;
            backward = false;
            left = false;
            right = true;
        }

        StartCoroutine(ResetDirection());
    }

    private void Update()
    {
        if(forward)
        {
            rb.velocity = transform.forward * randSpeed;
        }

        if(backward)
        {
            rb.velocity = -transform.forward * randSpeed;
        }

        if(left)
        {
            rb.velocity = -transform.right * randSpeed;
        }

        if(right)
        {
            rb.velocity = transform.right * randSpeed;
        }
    }

    IEnumerator ResetDirection()
    {
        yield return new WaitForSeconds(randSpeed);
        GetNumber();
    }
}
