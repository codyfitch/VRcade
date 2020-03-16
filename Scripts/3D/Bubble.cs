using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Rigidbody rb;
    public int speed;
    public GameObject popAni;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Transform bubbles forward from gun
        rb.AddForce(transform.forward * speed);
        StartCoroutine(Pop());
    }

    IEnumerator Pop()
    {
        yield return new WaitForSeconds(2f);
        //Play pop animation
        Instantiate(popAni, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
