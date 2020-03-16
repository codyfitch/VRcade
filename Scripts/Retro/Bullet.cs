using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    GameObject bulletSpawner;
    Score score;
    AudioSource AS;
    public GameObject explosionAni;

    void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
        bulletSpawner = GameObject.Find("LBulletSpawner");
        rb = GetComponent<Rigidbody>();
        AS = GameObject.Find("GameManager").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //Bullet moves forward at 100 speed
        rb.AddForce(transform.forward * 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if bullet hits an asteroid...
        if(collision.gameObject.tag == "Asteroid")
        {
            score.score += 100; //Add 100 to player score
            AS.Play(); //Play explosion sound
            Instantiate(explosionAni, transform.position, transform.rotation); //Play explosion animation
            Destroy(collision.gameObject); //Destroy bullet
            Destroy(gameObject); //Destroy asteroid
        }
    }
}
