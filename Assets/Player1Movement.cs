using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public Rigidbody rb;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")) {
            rb.AddForce(20, 0 , 0);
        }

        if (Input.GetKey("w")) {
            rb.AddForce(0, 0, 20);
        }

        if (Input.GetKey("a")) {
            rb.AddForce(-20, 0, 0);
        }

        if (Input.GetKey("s")) {
            rb.AddForce(0, 0, -20);
        }

        if (Input.GetKey("space")) {
            rb.AddForce(0, 25, 0);
        }
    }
}
