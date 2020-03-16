using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShoot : MonoBehaviour
{
    public GameObject bubble;
    public GameObject lShooter;
    public GameObject rShooter;
    bool delayLeft = false;
    bool delayRight = false;

    void Update()
    {
        //When player presses left trigger, Instantiate a bubble from left gun
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0)
        {
            if (!delayLeft)
            {
                delayLeft = true;
                Instantiate(bubble, lShooter.transform.position, lShooter.transform.rotation);
                StartCoroutine(Delay());
            }
        }
        
        //When player presses right trigger, instantiate a bubble from right gun
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
            if (!delayRight)
            {
                delayRight = true;
                Instantiate(bubble, rShooter.transform.position, rShooter.transform.rotation);
                StartCoroutine(Delay());
            }
        }
    }

    //Set delay to space out shots
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        if (delayLeft)
        {
            delayLeft = false;
        }

        if(delayRight)
        {
            delayRight = false;
        }
    }
}
