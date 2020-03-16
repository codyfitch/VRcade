using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGames : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //If player touches retro machine, load retro game
        if(other.name == "RetroMachine")
        {
            SceneManager.LoadScene("Retro");
        }

        //Load vector game
        if(other.name == "VectorMachine")
        {
            SceneManager.LoadScene("Vector");
        }
        //Load 3D game
        if(other.name == "3DMachine")
        {
            SceneManager.LoadScene("Basic3D");
        }
    }
}
