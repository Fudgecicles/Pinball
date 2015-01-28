using UnityEngine;
using System.Collections;

public class BurstOnHit : MonoBehaviour
{

    private GameObject particle;

	// Use this for initialization
	void Start ()
	{
	    particle = Resources.Load<GameObject>("Prefabs/BurstParticle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            GameObject temp = (GameObject)Instantiate(particle, transform.position, Quaternion.identity);
            StartCoroutine(cleanup(temp));
        }
        
    }

    IEnumerator cleanup(GameObject temp)
    {
        yield return new WaitForSeconds(1);
        Destroy(temp);
    }
}
