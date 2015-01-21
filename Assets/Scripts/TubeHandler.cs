using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Runtime.Remoting;

public class TubeHandler : MonoBehaviour
{

    private AreaEffector2D[] effectors;
    private float[] degrees;
    private bool inside;
    private GameObject ball;
    private GameObject cloneBall;
    private bool cantSpawn;
    private bool hitTop;
    private bool hitBottom;
    private IEnumerator fizzleInstance;
    private GameManager manager;


	// Use this for initialization
	void Start ()
	{
	    manager = GameObject.Find("Canvas").GetComponent<GameManager>();
        ball = (GameObject)Resources.Load("Prefabs/PlayerBall");
	    effectors = GetComponentsInChildren<AreaEffector2D>();
        degrees = new float[effectors.Count()];
	    for (int k = 0; k < effectors.Count(); k++)
	    {
	        degrees[k] = effectors[k].forceDirection;
	    }
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!cantSpawn)
        {
            if (!inside)
            {
                if (col.transform.position.y > 22)
                {
                    hitTop = true;
                    for (int k = 0; k < effectors.Count(); k++)
                    {
                        effectors[k].forceDirection = degrees[k];
                    }
                }
                else
                {
                    hitBottom = true;
                    for (int k = 0; k < effectors.Count(); k++)
                    {
                        effectors[k].forceDirection = degrees[k] + 180;
                    }
                }
                cloneBall = (GameObject) Instantiate(ball, col.transform.position, Quaternion.identity);
                inside = true;
                fizzleInstance = fizzle(cloneBall);
                StartCoroutine(fizzleInstance);
            }
            else
            {
                cantSpawn = true;
                inside = false;
                StartCoroutine(resetSpawn());
                cloneBall.GetComponent<CircleCollider2D>().enabled = true;
                cloneBall.GetComponent<Rigidbody2D>().gravityScale = 5;
                if (col.transform.position.y > 22)
                {
                    if (hitBottom)
                    {
                        StopCoroutine(fizzleInstance);
                        cloneBall.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
                        cloneBall.layer = 0;
                        manager.lives += 1;

                    }
                    else
                    {
                        stop(cloneBall);
                    }
                }
                else
                {
                    if (hitTop)
                    {
                        StopCoroutine(fizzleInstance);
                        cloneBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -50);
                        cloneBall.layer = 0;
                        manager.lives += 1;
                    }
                    else
                    {
                        stop(cloneBall);
                    }
                }
                for (int k = 0; k < effectors.Count(); k++)
                {
                    effectors[k].enabled = false;
                }
                hitTop = false;
                hitBottom = false;
            }
        }
    }

    IEnumerator resetSpawn()
    {
        yield return new WaitForSeconds(3);
        cantSpawn = false;
        inside = false;
        hitTop = false;
        hitBottom = false;
        for (int k = 0; k < effectors.Count(); k++)
        {
            effectors[k].enabled = true;
        }
    }

    IEnumerator fizzle(GameObject tempParticle)
    {
        yield return new WaitForSeconds(6);
        stop(tempParticle);
        Destroy(tempParticle);
    }

    void stop(GameObject particles)
    {
        ParticleSystem[] systems = particles.GetComponentsInChildren<ParticleSystem>();
        for (int k = 0; k < systems.Count(); k++)
        {
            systems[k].Stop();
        }
    }

    public void toggleColliders()
    {
        if (effectors[0].enabled == true)
        {
            for (int k = 0; k < effectors.Count(); k++)
            {
                effectors[k].enabled = false;
            }
        }
        else
        {
            for (int k = 0; k < effectors.Count(); k++)
            {
                effectors[k].enabled = true;
            }
        }
    }
}
