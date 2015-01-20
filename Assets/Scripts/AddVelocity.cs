using UnityEngine;
using System.Collections;

public class AddVelocity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(100,0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
