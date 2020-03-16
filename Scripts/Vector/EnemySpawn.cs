using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;

    public int enemyCount;

    public bool enemy1 = false;
    public bool enemy2 = false;
    public bool enemy3 = false;
    public bool enemy4 = false;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        enemyCount = 4; //Set enemy count to 4
        //Spawn enemies
        Instantiate(enemies[0], spawn1.transform.position, spawn1.transform.rotation);
        Instantiate(enemies[1], spawn2.transform.position, spawn2.transform.rotation);
        Instantiate(enemies[2], spawn3.transform.position, spawn3.transform.rotation);
        Instantiate(enemies[3], spawn4.transform.position, spawn4.transform.rotation);
    }

    private void Update()
    {
        Debug.Log("Enemy Count: " + enemyCount);
        if(enemyCount <= 0) //When enemy count is 0 (when all enemies are destroyed), spawn new wave
        {
            Debug.Log("Respawn enemies");
            SpawnEnemy();
        }
    }
}
