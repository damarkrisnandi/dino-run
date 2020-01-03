﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public Rigidbody rb;
    public bool isGrounded;
    public Vector3 startingPoint;
    // Update is called once per frame

    void Start(){
        rb = GetComponent<Rigidbody>();
        startingPoint = transform.position;
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.collider.name == "Arena") {
            isGrounded = true;
        } else {
            Debug.Log("Nabrak Kaktus");
            transform.position = startingPoint;
        }
        
    }

    void FixedUpdate()
    {
        // rb.AddForce(new Vector3(5, 0 , 0));

        if (Input.GetKey("space") & isGrounded == true) {
            rb.AddForce(new Vector3(-1, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
