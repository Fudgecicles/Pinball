using UnityEngine;
using System.Collections;

public class ParticleBall : MonoBehaviour {

    public float radius = 5;
    public float numParticles = 50;
    GameObject particle;
    private Vector2 leftWaypoint;
    private Vector2 rightWaypoint;
    public float moveTime = 10;

	// Use this for initialization
	void Start ()
	{
	    leftWaypoint = transform.FindChild("Waypoint1").position;
	    rightWaypoint = transform.FindChild("Waypoint2").position;
        particle = (GameObject)Resources.Load("Prefabs/prf_particle");
        for (int k = 0; k < numParticles; k++)
        {
            float r = (float)Random.Range(0, radius/2)+radius/2;
            float d = Random.Range(0, 2 * Mathf.PI);
            float x = this.transform.position.x+Mathf.Sqrt(r) * Mathf.Cos(d);
            float y = transform.position.y+Mathf.Sqrt(r) * Mathf.Sin(d);
            GameObject temp = (GameObject)Instantiate(particle, new Vector2(x, y), Quaternion.identity);
            temp.transform.parent = this.transform;
        }
	    StartCoroutine(moveRight());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag!="Player")
        {
            col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            float r = (float) Random.Range(0, radius/2) + radius/2;
            float d = Random.Range(0, 2*Mathf.PI);
            float x = this.transform.position.x + Mathf.Sqrt(r)*Mathf.Cos(d);
            float y = transform.position.y + Mathf.Sqrt(r)*Mathf.Sin(d);
            col.transform.position = new Vector2(x, y);

        }
    }

    IEnumerator moveRight()
    {
        Vector2 pos = transform.position;
        float timer=0;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector2.Lerp(pos, rightWaypoint, timer/moveTime);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(moveLeft());
    }

    IEnumerator moveLeft()
    {
        Vector2 pos = transform.position;
        float timer = 0;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector2.Lerp(pos, leftWaypoint, timer / moveTime);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(moveRight());
    }
}
