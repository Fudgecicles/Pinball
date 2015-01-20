﻿using UnityEngine;
using System.Collections;
using Microsoft.Win32;


public class BallShooter : MonoBehaviour
{

    private bool hasBall = true;
    private float timer;
    private GameObject ball;
    public float maxVelocity = 100;
    public float chargeTime = 5;

	// Use this for initialization
	void Start ()
	{
	    ball = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
       
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (hasBall)
	        {
	            if (ball == null)
	            {
	                ball = GameObject.FindGameObjectWithTag("Player");
	            }
	            StartCoroutine(chargeHit());
	        }     
	    }
	}

    IEnumerator chargeHit()
    {
        while (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log(timer);
        float temp = Mathf.Min(timer, chargeTime);
        temp = temp/chargeTime;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,temp*maxVelocity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.position.y > 22)
        {
            ball.layer = 0;
        }
        else
        {
            if(hasBall)
                hasBall = false;
            else
            {
                hasBall = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.position.y < -10.9)
        {
            hasBall = true;
        }
    }
}