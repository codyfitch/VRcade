using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    private int hitPoints = 3;
    public GameObject hitScreen;
    public Text gameOverText;
    public Text scoreText;
    Score score;
    public GameObject[] asteroidSpawners;
    public GameObject lGun;
    public GameObject rGun;

    private void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if player is hit by an asteroid...
        if (collision.gameObject.tag == "Asteroid")
        {
            Debug.Log("Player Hit");
            Destroy(collision.gameObject); //Destroy asteroid
            if (hitPoints > 1) //if hitpoints are more than 1 (0 to player)
            {
                hitPoints--; //Subtract 1 hit point
                Debug.Log("Hitpoints: " + hitPoints);
                hitScreen.SetActive(true); //turn on hit screen (white flash)
                StartCoroutine(ScreenOff()); //Turn hit screen off
            } else if(hitPoints <= 1) //if hitpoints are less than or equal to 1
            {
                Dead(); //Player is dead
            }            
        }
    }

    IEnumerator ScreenOff()
    {
        yield return new WaitForSeconds(0.1f);
        hitScreen.SetActive(false);
    }

    void Dead()
    {
        Debug.Log("Dead!");
        GetComponent<CapsuleCollider>().enabled = false;
        //Destroy guns
        Destroy(lGun);
        Destroy(rGun);
        hitScreen.SetActive(true); //Turn on final screen (black screen)
        gameOverText.text = "Game Over!"; //Show "Game Over!"
        scoreText.text = "Score: " + score.score; //Show final score
        foreach(GameObject asteroidSpawn in asteroidSpawners) //Destroy asteroid spawners to stop asteroids
        {
            Destroy(asteroidSpawn);
        }
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu"); //Load back to menu/arcade
    }
}
