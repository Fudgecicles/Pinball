using UnityEngine;
using System.Collections;

public class expandOnHit : MonoBehaviour
{

    private Transform child;
    public float expansionMultiplayer = 1.2f;
    public float movementTime = .05f;

	// Use this for initialization
	void Start ()
	{
	    child = transform.FindChild("mesh");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator expand()
    {
        Vector3 original = child.localScale;
        float timer=0;
        while (timer < movementTime)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(original, original*expansionMultiplayer, timer/movementTime);
            yield return new WaitForEndOfFrame();
        }
        timer = 0;
        while (timer < movementTime)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(original * expansionMultiplayer, original , timer / movementTime);
            yield return new WaitForEndOfFrame();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            StartCoroutine(expand());
        }
    }
}
