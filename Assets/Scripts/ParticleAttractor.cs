using UnityEngine;
using System.Collections;

public class ParticleAttractor : MonoBehaviour {

    ParticleSystem pSystem;
    ParticleSystem.Particle[] particles;
    int numParticles;
    public float dropoffRange = 10;
    public float pullStrenght = 10;

	// Use this for initialization
	void Start () {
        pSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        numParticles = pSystem.GetParticles(particles);

	}
}
