using UnityEngine;
using System.Collections;

public class ParticleBall : MonoBehaviour {

    public float radius = 5;
    public float numParticles = 50;
    GameObject particle;


	// Use this for initialization
	void Start () {
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
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
