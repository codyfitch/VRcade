using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHit : MonoBehaviour
{
//If bullet reaches level edge, destroy it
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
