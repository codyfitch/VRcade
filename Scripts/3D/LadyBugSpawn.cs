using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBugSpawn : MonoBehaviour
{
    public GameObject ladybug;
    int randNum;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        randNum = Random.Range(5, 20); //Random timer that determines when ladybugs spawn (in seconds)
        StartCoroutine(ResetSpawn());
    }

    IEnumerator ResetSpawn()
    {
        yield return new WaitForSeconds(randNum);
        Instantiate(ladybug, transform.position, transform.rotation); //Spawn ladybug
        Spawn(); //Reset timer for new spawns
    }
}
