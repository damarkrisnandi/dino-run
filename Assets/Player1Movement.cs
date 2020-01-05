using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;
using System;

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
    
    public GameObject cactees3;
    public GameObject cactees2;
    public GameObject cactees1;

    public float score;
    public TextMesh text;
    public float highScore;
    public TextMesh hs;
    public TextMesh message;

    void Start(){
        cf = GetComponent<ConstantForce>();
        rb = GetComponent<Rigidbody>();
        GenerateObstacle();

        startingPoint = transform.position;
        isAccel = false;
        isPlayOn = false;
        isGameOver = false;
        message.text = "Press Enter to Start the game";
    }

    public static System.Random random;
    int r = 50;
    int type;
    void GenerateObstacle() {
        for (int x = 1; x <= 100; x++) {
            random = new System.Random();
            r += random.Next(20,25);
            if (x <= 10) {
                r = r - 0;
            } else if (x <= 25) {
                r -= 8;
            } else if (x <= 50) {
                r -= 12;
            } else {
                r -= 15;
            }
            
            type = random.Next(1,3);
            switch (type)
            {
                case 1: 
                    Instantiate(cactees3, startingPoint + new Vector3(2*r, 1f, 0), Quaternion.identity);
                    break;
                case 2: 
                    Instantiate(cactees2, startingPoint + new Vector3(2*r, 1f, 0), Quaternion.identity);
                    break;
                case 3: 
                    Instantiate(cactees1, startingPoint + new Vector3(2*r, 1f, 0), Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
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
        
        PlayGame();

        GameOver();

        UpdateScore();
    }

    void StartGame() {
        if (isGameOver == false) {
            if (Input.GetKey(KeyCode.Return)) {
                isPlayOn = true;
                transform.position = startingPoint;
                message.text = "";
            }
        } else {
            if (Input.GetKey(KeyCode.Return)) {
                transform.position = startingPoint;
                isGameOver = false;
            }
        }
        
    }

    void PlayGame() {
        if (isPlayOn == true) {
            if (isAccel == false) {
                getVelocity();
            }
            // rb.AddForce(new Vector3(5, 0 , 0));

            if (Input.GetKey("space") & isGrounded == true) {
                rb.AddForce(new Vector3(-3, 5, 0), ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    void GameOver() {
        if (isGameOver == true) {
            cf.force = new Vector3(0, 0, 0);
            isPlayOn = false;

            // get score
            if (highScore < score) {
                highScore = score;
            }
            hs.text = "High Score: " + Math.Floor(highScore).ToString();
            message.text = "Press Enter to Restart the game";
        }
    }

    void UpdateScore() {
        if (isPlayOn == true) {
            score += 0.1f;
            text.text = Math.Floor(score).ToString();
        }

        if (transform.position == startingPoint) {
            score = 0f;
        }
    }
}
