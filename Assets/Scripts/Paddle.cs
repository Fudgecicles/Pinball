using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    Rigidbody2D leftPaddle;
    Rigidbody2D rightPaddle;
    public float strength=30000;
    public float sustain = 10000;

	// Use this for initialization
	void Start () {
        leftPaddle = transform.GetChild(1).GetComponent<Rigidbody2D>();
        rightPaddle = transform.GetChild(0).GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftPaddle.AddTorque(strength);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightPaddle.AddTorque(-strength);
        }
	    if (Input.GetKey(KeyCode.LeftArrow))
	    {
	        leftPaddle.AddTorque(sustain);
	    }
	    if (Input.GetKey(KeyCode.RightArrow))
	    {
	        rightPaddle.AddTorque(-sustain);
	    }

	}
}
