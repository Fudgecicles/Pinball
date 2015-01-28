using UnityEngine;
using System.Collections;

public class SpawnParticles : MonoBehaviour
{

    private GameObject particles;
    private Rigidbody2D body;


	// Use this for initialization
	void Start ()
	{
	    particles = Resources.Load<GameObject>("Prefabs/particleShooter");
	    body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag != "DontSpawn")
        {
            GameObject temp = (GameObject) Instantiate(particles, col.contacts[0].point, Quaternion.identity);
            temp.transform.up = col.contacts[0].normal;
            ParticleShooter shooter = temp.GetComponent<ParticleShooter>();
            shooter.numParticles = (int) body.velocity.magnitude/2;
        }
    }
}
