using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("Menu"); //When player hits B button, return to menu/arcade
        }
    }
}
