using UnityEngine;
using System.Collections;
using System.Net.Mime;

public class FloatUp : MonoBehaviour
{

    private float timer;
    public float travelTime;
    public float distance;
    private Vector2 destination;
    private Vector2 initialPos;
    private TextMesh mesh;
    private Color original;

	// Use this for initialization
	void Start () {
	    destination = new Vector2(transform.position.x,transform.position.y+distance);
	    initialPos = transform.position;
	    mesh = GetComponent<TextMesh>();
	    original = mesh.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
        
	    timer += Time.deltaTime;
        if(timer>travelTime)
            Destroy(gameObject);
        
	    mesh.color = new Color(original.r,original.g,original.b,1-timer/travelTime);
        transform.position = Vector2.Lerp(initialPos, destination, timer/travelTime);
	    transform.position = new Vector2(.2f*Mathf.Sin(timer*10) + initialPos.x, transform.position.y);

	}
}
