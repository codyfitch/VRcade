using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLaser : MonoBehaviour
{
    Rigidbody rb;
    public GameObject explosionAni;
    VectorScore vectorScore;
    GameObject gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager");
        vectorScore = gameManager.GetComponent<VectorScore>();
    }

    void FixedUpdate()
    {
        rb.AddForce(-transform.up * 100); //Laser moves forward
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if laser hits an enemy bullet...
        if (collision.gameObject.tag == "Bullet")
        {
            vectorScore.score += 5; //Add 5 to player score
            Instantiate(explosionAni, transform.position, transform.rotation); //Instantiate explosion animation
            Destroy(collision.gameObject); //Destory bullet
            Destroy(gameObject); //Destroy laser
        }
    }
}
