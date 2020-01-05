using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public Rigidbody rb;
    public bool isGrounded;
    public Vector3 startingPoint;
    public bool isAccel;
    public bool isPlayOn;
    public bool isGameOver;
    public ConstantForce cf;
    public float constantSpeed = 10f;
    // Update is called once per frame

    void Start(){
        cf = GetComponent<ConstantForce>();
        rb = GetComponent<Rigidbody>();
        startingPoint = transform.position;
        isAccel = false;
        isPlayOn = false;
        isGameOver = false;
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.collider.name == "Arena") {
            isGrounded = true;
        } else {
            isGameOver = true;
        }
        
    }

    
    // public float smoothingFactor  = 1.0f;
 
    void getVelocity()
    {
        cf.force = new Vector3(5, 0, 0);
    }

    void FixedUpdate()
    {
        StartGame();
        if (isPlayOn == true) {
            PlayGame();
        }
        GameOver();
    }

    void StartGame() {
        if (isGameOver == false) {
            if (Input.GetKey(KeyCode.Return)) {
            isPlayOn = true;
            transform.position = startingPoint;
            // constantSpeed = 10f;
            }
        } else {
            if (Input.GetKey(KeyCode.Return)) {
                transform.position = startingPoint;
                isGameOver = false;
            }
        }
        
    }

    void PlayGame() {
        if (isAccel == false) {
            getVelocity();
        }
        // rb.AddForce(new Vector3(5, 0 , 0));

        if (Input.GetKey("space") & isGrounded == true) {
            rb.AddForce(new Vector3(-2, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void GameOver() {
        if (isGameOver == true) {
            cf.force = new Vector3(0, 0, 0);
            isPlayOn = false;
        }
    }
}
