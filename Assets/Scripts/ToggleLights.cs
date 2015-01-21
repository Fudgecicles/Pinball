using UnityEngine;
using System.Collections;
using System.Linq;
using System.Net;

public class ToggleLights : MonoBehaviour
{

    private Light[] lights;
    public float pause = 1;

	// Use this for initialization
	void Start ()
	{
	    lights = GetComponentsInChildren<Light>();
	    for (int k = 0; k < lights.Count(); k++)
	    {
	        lights[k].enabled = false;
	    }
	    StartCoroutine(toggleLights(0));
	    StartCoroutine(toggleLights(4));
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator toggleLights(int a)
    {
        //bool even = false;
        int k = a;
        int prev=1;
        while (true)
        {
            
            lights[k].enabled = true;
            lights[prev].enabled = false;
            prev = k;
            k++;
            if (k == lights.Count())
            {
                k = 0;
            }
            /*
            for (int k = 0; k < lights.Count(); k++)
            {
                if (k%2 == 0)
                {
                    if (even)
                    {
                        lights[k].enabled = true;
                    }
                    else
                    {
                        lights[k].enabled = false;
                    }
                }
                else
                {
                    if (even)
                    {
                        lights[k].enabled = false;
                    }
                    else
                    {
                        lights[k].enabled = true;
                    }
                }
                
            }
            if (even)
                even = false;
            else
                even = true;
             */
            
            yield return new WaitForSeconds(pause);
        }

    }
}
