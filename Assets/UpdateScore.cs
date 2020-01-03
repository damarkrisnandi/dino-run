using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateScore : MonoBehaviour
{
    public TextMesh text;
    public double score = 0;
    public Vector3 sp;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();
        sp = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        score += 0.1;
        text.text = Math.Floor(score).ToString();

        if (transform.position == sp) {
            score = 0;
        }
    }
}
