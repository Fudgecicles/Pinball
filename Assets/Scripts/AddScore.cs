using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour
{

    private GameManager manager;
    public int points = 100;

	// Use this for initialization
	void Start ()
	{
	    manager = GameObject.Find("Canvas").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        manager.updateScore(points);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        manager.updateScore(points);
    }
}
