using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    float timerRand;

    private void Start()
    {
        Randomize();
    }

    void Randomize()
    {
        timerRand = Random.Range(0f, 10.0f); //Randomize when enemies fire
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(timerRand);

        GameObject asteroid = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject; //spawn enemy bullet
        Randomize(); //Reset to fire again
    }
}