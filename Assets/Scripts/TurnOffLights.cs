using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Rendering;

public class TurnOffLights : MonoBehaviour
{

    private Light[] lights;
    private GameObject[] objects;
    private ToggleLights changer;
    private float intensity;
    

	// Use this for initialization
	void Start () {

        objects = GameObject.FindGameObjectsWithTag("Disable");
        lights = new Light[objects.Count()];
        for (int k = 0; k < objects.Count(); k++)
        {
            lights[k] = objects[k].GetComponent<Light>();
        }
	    changer = GameObject.Find("Arrows").GetComponent<ToggleLights>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            bool off;
            if (lights[0].enabled = true)
                off = true;
            else
            {
                off = false;
            }
            for (int k = 0; k < lights.Count(); k++)
            {
                if (off)
                {
                    lights[k].enabled = false;
                }
                else
                {
                    lights[k].enabled = true;
                }
            }
            if (changer.enabled)
            {
                changer.enabled = false;
                changer.stopToggle();
            }
            else
            {
                changer.enabled = true;
                changer.restartToggle();
            }
            if (RenderSettings.ambientSkyColor.r < .5)
            {
                RenderSettings.ambientSkyColor = Color.white;
            }
            else
            {
                RenderSettings.ambientSkyColor = Color.black;
            }
            
        }
    }
}
