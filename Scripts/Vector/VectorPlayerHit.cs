using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VectorPlayerHit : MonoBehaviour
{
    private int hitPoints = 3;
    public Text lives;
    public Text score;
    public GameObject gameOverText;
    public GameObject LGun;
    public GameObject RGun;
    public GameObject blackScreen;
    VectorScore vectorScore;
    public GameObject gameManager;

    private void Start()
    {
        vectorScore = gameManager.GetComponent<VectorScore>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if enemy bullet hits player...
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); //Destroy the bullet
            if (hitPoints > 1) //if player HP is more than 1
            {
                Debug.Log("Player Hit");
                hitPoints--; //subtract 1 HP from player
            } else if (hitPoints <= 1) // else player is dead
            {
                Dead();
            }
        }
    }

    private void Update()
    {
        lives.text = "LIVES: " + hitPoints.ToString(); //Display how many lives player has remaining
    }
    void Dead()
    {
        Debug.Log("You are dead!");
        blackScreen.SetActive(true); //Turn on black screen
        gameOverText.SetActive(true); //Show "Game Over!"
        score.text = "Score: " + vectorScore.score; //Show final score
        //Destroy guns
        Destroy(LGun);
        Destroy(RGun);
        if(gameObject.tag == "Enemy")
        {
            Destroy(gameObject); //Destroy all remaining enemies
        }

        StartCoroutine(EndGame());       
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu"); //Load menu/arcade
    }
}
