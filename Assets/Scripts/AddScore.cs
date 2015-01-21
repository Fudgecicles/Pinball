using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour
{

    private GameManager manager;
    public int points = 100;
    private GameObject text;

	// Use this for initialization
	void Start ()
	{
	    text = Resources.Load<GameObject>("Prefabs/Text");
	    manager = GameObject.Find("Canvas").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        manager.updateScore(points);
        TextMesh temp = ((GameObject)Instantiate(text, col.transform.position, Quaternion.identity)).GetComponent<TextMesh>();
        temp.text = points.ToString();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        manager.updateScore(points);
        TextMesh temp = ((GameObject)Instantiate(text, col.transform.position, Quaternion.identity)).GetComponent<TextMesh>();
        temp.text = points.ToString();
    }
}
