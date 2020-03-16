using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGame : MonoBehaviour
{
    public GameObject retroScreen;
    public GameObject vectorScreen;
    public GameObject bubbleScreen;
    public GameObject player;

    //Teleport locations (in front of each machine)
    public GameObject retroMarker;
    public GameObject vectorMarker;
    public GameObject bubbleMarker;

    bool retroOn = false;
    bool vectorOn = false;
    bool bubbleOn = false;

    private void Update()
    {
        RaycastHit hit;
        //Raycast from hand
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000.0f))
        {
            //If raycast hits retro machine, turn on its screen
            if (hit.collider.name == "RetroMachine")
            {
                retroScreen.SetActive(true);
                retroOn = true;
            }
            else //Otherwise turn off screen
            {
                retroScreen.SetActive(false);
                retroOn = false;
            }

            //Vector machine
            if (hit.collider.name == "VectorMachine")
            {
                vectorScreen.SetActive(true);
                vectorOn = true;
            }
            else
            {
                vectorScreen.SetActive(false);
                vectorOn = false;
            }
            //3D machine
            if (hit.collider.name == "3DMachine")
            {
                bubbleScreen.SetActive(true);
                bubbleOn = true;
            }
            else
            {
                bubbleScreen.SetActive(false);
                bubbleOn = false;
            }
        }
        //When player presses trigger...
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0)
        {
            if(retroOn)
            {
                //Teleport to retro machine if raycast hits it
                player.transform.position = retroMarker.transform.position;
                //Keep machine's screen on and prevent others from turning on
                retroScreen.SetActive(true);
                vectorScreen.SetActive(false);
                bubbleScreen.SetActive(false);
            }

            if(vectorOn)
            {
                //Teleport to vector machine
                player.transform.position = vectorMarker.transform.position;
                retroScreen.SetActive(false);
                vectorScreen.SetActive(true);
                bubbleScreen.SetActive(false);
            }

            if(bubbleOn)
            {
                //Teleport to 3d machine
                player.transform.position = bubbleMarker.transform.position;
                retroScreen.SetActive(false);
                vectorScreen.SetActive(false);
                bubbleScreen.SetActive(true);
            }
        }
    }
}
