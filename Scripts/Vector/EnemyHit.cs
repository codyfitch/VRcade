using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    int hitPoints = 10;
    public GameObject shipParts;
    GameObject gameManager;
    VectorScore vectorScore;
    public GameObject explosionAni;
    EnemySpawn enemySpawn;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        vectorScore = gameManager.GetComponent<VectorScore>();
        enemySpawn = gameManager.GetComponent<EnemySpawn>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        //if enemy is hit by player laser...
        if(collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject); //Destroy laser

            if(hitPoints >= 1) //if enemy hitpoints are above 1
            {
                vectorScore.score += 10; //Add 10 points to player score
                hitPoints--; //Subtract 1 HP
                shipParts.SetActive(false); //Set ship inactive
                StartCoroutine(ResetEnemy()); //Turn ship back on (flash when hit)
            } else if(hitPoints <= 1) //Else if enemy HP is less than 1...
            {
                Instantiate(explosionAni, transform.position, transform.rotation); //Spawn explosion animation
                vectorScore.score += 100; //Add 100 points to player score
                enemySpawn.enemyCount--; //Subtract 1 from player count
                Destroy(gameObject); //Destroy enemy
            }
        }
    }

    IEnumerator ResetEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        shipParts.SetActive(true);
    }
}
