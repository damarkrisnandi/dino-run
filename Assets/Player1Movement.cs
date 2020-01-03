using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public Rigidbody rb;
    public bool isGrounded;
    public Vector3 startingPoint;
    public bool isAccel;
    // Update is called once per frame

    void Start(){
        rb = GetComponent<Rigidbody>();
        startingPoint = transform.position;
        isAccel = false;
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

    public float constantSpeed;
    public float smoothingFactor  = 1.0f;
 
    void getVelocity()
    {
        rb.velocity = constantSpeed * (rb.velocity.normalized);
    }

    void FixedUpdate()
    {
        if (isAccel == false) {
            getVelocity();
        }
        // rb.AddForce(new Vector3(5, 0 , 0));

        if (Input.GetKey("space") & isGrounded == true) {
            rb.AddForce(new Vector3(0, constantSpeed, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
