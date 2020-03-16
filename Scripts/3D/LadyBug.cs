using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBug : MonoBehaviour
{
    public GameObject bubble;
    bool bubbled = false;
    Rigidbody rb;
    public GameObject popAni;
    GameObject player;
    GameObject cam;
    Vector3 newDirection;
    bubbleScore score;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("LadybugAttractor"); //Ladybugs go to a separate object on player to control angle
        cam = GameObject.Find("Player");
        score = GameObject.Find("GameManager").GetComponent<bubbleScore>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If ladybug is hit by a bubble
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); //Destroy the bubble
            bubble.SetActive(true); //Turn on ladybug bubble
            bubbled = true; //When bubbled is true, ladybug floats up (below in update)
        }
    }

    private void Update()
    {
        float step = 2 * Time.deltaTime; //Set ladybug speed
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step); //Ladybugs always move toward player
        transform.LookAt(cam.transform); //Ladybugs are always rotated toward player

        if (bubbled)
        {
            transform.position = transform.position; //Stops ladybug
            rb.AddForce(transform.up * 2); //Ladybugs float into the air
            StartCoroutine(Pop());
        }
    }

    IEnumerator Pop()
    {
        yield return new WaitForSeconds(2f);
        //play pop animation
        Instantiate(popAni, transform.position, transform.rotation); //After seconds, spawn pop animation 
        score.score += 100; //Add 100 to player's score
        Destroy(gameObject); //Destroy ladybug
    }
}
