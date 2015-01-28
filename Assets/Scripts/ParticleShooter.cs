using UnityEngine;
using System.Collections;
using System.Linq.Expressions;

public class ParticleShooter : MonoBehaviour
{

    public int numParticles;
    public float angle;
    public float velocity;
    private GameObject particle;
    private GameObject[] spawnParticles;
    private ParticleSystem[] system;
    public float fizzleTime;

	// Use this for initialization
	void Start ()
	{
	    particle = Resources.Load<GameObject>("Prefabs/prf_colParticle");
        spawnParticles = new GameObject[numParticles];
	    system = new ParticleSystem[numParticles];
	    for (int k = 0; k < numParticles; k++)
	    {
	        float curAngle = Random.Range(-angle, angle);
	        float curVel = Random.Range(velocity/2, velocity);
	        Vector2 newUp = Quaternion.AngleAxis(curAngle, Vector3.forward)*transform.up;
	        GameObject temp = (GameObject)Instantiate(particle, transform.position, Quaternion.identity);
	        temp.transform.up = newUp;
	        temp.GetComponent<Rigidbody2D>().velocity = newUp.normalized*curVel;
	        spawnParticles[k] = temp;
	        system[k] = temp.GetComponentInChildren<ParticleSystem>();

	    }
	    StartCoroutine(cleanup());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator cleanup()
    {
        float timer=0;
        float[] rates = new float[numParticles];
        for (int k = 0; k < numParticles; k++)
        {
            rates[k] = system[k].emissionRate;
        }
        while (timer < fizzleTime)
        {
            timer += .1f;
            for (int k = 0; k < numParticles; k++)
            {
                system[k].emissionRate = rates[k]*(1-timer/fizzleTime);
            }
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(1);
        for (int k = 0; k < numParticles; k++)
        {
            Destroy(spawnParticles[k]);
        }
        Destroy(gameObject);
    }
}
