using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitPlay : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBubble;
    Rigidbody rb;
    public GameObject fader;
    Animator fadeAni;
    public GameObject lGun;
    public GameObject rGun;
    public GameObject spawners;
    GameObject spawnedBugs;
    public GameObject gameOverText;
    public Text scoreText;
    bubbleScore score;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        fadeAni = fader.GetComponent<Animator>();
        spawnedBugs = GameObject.FindGameObjectWithTag("Ladybug");
        score = GameObject.Find("GameManager").GetComponent<bubbleScore>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //When ladybug hits player...
        if(collision.gameObject.tag == "Ladybug")
        {
            Debug.Log("Player Hit!");
            Destroy(collision.gameObject); //Destroy ladybug
            //Destroy both guns
            Destroy(lGun);
            Destroy(rGun);
            //Destroy spawners to stop bugs after player loses
            Destroy(spawners);
            Destroy(spawnedBugs);
            playerBubble.SetActive(true); //Bubble appears around player
            rb.AddForce(transform.up * 200); //Player floats into the sky
            StartCoroutine(Fading()); //Start fade sequence
        }
    }

    IEnumerator Fading()
    {
        yield return new WaitForSeconds(2f);
        fadeAni.SetBool("Fade", true); //Start fade animation

        yield return new WaitForSeconds(2f);
        playerBubble.SetActive(false); //Turn off bubble around player
        gameOverText.SetActive(true);  //Show "Game Over!" text
        scoreText.text = "Score: " + score.score.ToString(); //Show final score
    
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Menu"); //Load menu
    }
}
