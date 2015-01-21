using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

    float maxDistance = 4.5f;
    Transform parent;
    float rotation;
    float rotationMax = 1000;
    Rigidbody2D rb;
    Color col;
    ParticleSystem system;
    public Color lowerRange;
    public Color upperRange;

	// Use this for initialization
	void Start () {
        system = GetComponentInChildren<ParticleSystem>();
        parent = this.transform.parent;
        rotation = (float)Random.Range(0, rotationMax);
        rb = GetComponent<Rigidbody2D>();
        col = new Color(Random.Range(lowerRange.r, upperRange.r), Random.Range(lowerRange.g, upperRange.g), Random.Range(lowerRange.b, upperRange.b));
        system.startColor = col;
        maxDistance = transform.parent.GetComponent<ParticleBall>().radius*.9f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(parent.position, transform.position) > maxDistance)
        {
            //rb.velocity = new Vector2(0, 0);
            //rb.AddForce(parent.transform.position);
        }

        
        Vector2 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q,360); 
  

        Vector3 dif = transform.position - parent.position;
        Vector2 cross = Vector3.Cross(dif, new Vector3(0,0,1)).normalized;
        GetComponent<Rigidbody2D>().AddForce(cross * Time.deltaTime * rotation);
	}
}
