using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    bool delay = false;


    private void Update()
    {
        //left hand
        if (gameObject.name == "LBulletSpawner")
        {
            //When player pulls trigger...
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0)
            {
                if (!delay)
                {
                    delay = true; //Set dealy to control bullet spawn speed
                    GameObject blt = Instantiate(bullet, transform.position, transform.rotation) as GameObject; //Spawn bullet
                    StartCoroutine(Delay());
                }
            }
        }
        //right hand
        else if (gameObject.name == "RBulletSpawner")
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
            {
                if (!delay)
                {
                    delay = true;
                    GameObject blt = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                    StartCoroutine(Delay());
                }
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        delay = false;
        
    }
}
