using UnityEngine;
using System.Collections;
using System.Linq;

public class ResetBall : MonoBehaviour
{

    private GameManager manager;
    private Vector3 respawnPoint;
    private GameObject ball;

	// Use this for initialization
	void Start ()
	{
	    respawnPoint = transform.FindChild("RespawnPoint").position;
	    manager = GameObject.Find("Canvas").GetComponent<GameManager>();
	    ball = Resources.Load<GameObject>("Prefabs/PlayerBall");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            manager.updateLives(-1);
            if (GameObject.FindGameObjectsWithTag("Player").Count() < 2)
            {
                if (manager.lives > 0)
                {
                    GameObject temp = (GameObject) Instantiate(ball, respawnPoint, Quaternion.identity);
                    temp.GetComponent<Rigidbody2D>().gravityScale = 5;
                    temp.GetComponent<CircleCollider2D>().enabled = true;
                    GameObject.Find("Start").layer = 10;
                }
            }
            else
            {
                Debug.Log(GameObject.FindGameObjectWithTag("Player").name);
            }
        }
    }
}
