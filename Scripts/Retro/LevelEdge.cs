using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEdge : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //If an asteroid hits the edge of level, destroy it
        if(collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
        }
    }
}
