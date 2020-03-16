using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSideSpawner : MonoBehaviour
{
    public GameObject[] asteroids;
    float timerRand;

    private void Start()
    {
        Randomize();
    }

    private void Update()
    {
        //transform.position = new Vector3(Mathf.PingPong(Time.time * 2, 20 - 1) + 1, transform.position.y, transform.position.x);
    }

    void Randomize()
    {
        //Set up random float for spawn timer
        timerRand = Random.Range(0f, 10.0f);
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(timerRand);

        //Instantiate random asteroid
        int randomNum = Random.Range(0, asteroids.Length);
        GameObject asteroid = Instantiate(asteroids[randomNum], transform.position, Quaternion.identity) as GameObject;
        Randomize();
    }
}
