using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public int lives = 3;
    public int score = 0;
    private GameObject buttons;
    private UnityEngine.UI.Text[] texts;

	// Use this for initialization
	void Start ()
	{
	    buttons = transform.FindChild("Buttons").gameObject;
	    texts = GetComponentsInChildren<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown((KeyCode.Escape)))
	    {
	        togglePause();
	    }
	}

    public void updateScore(int tempScore)
    {
        score += tempScore;
        texts[1].text = "Score: " + score;
    }

    public void updateLives(int tempLives)
    {
        lives += tempLives;
        texts[0].text = "Lives: " + lives;
        if (lives == 0)
        {
            buttons.SetActive(true);
        }
    }

    public void togglePause()
    {
        if (lives > 0)
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                buttons.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                buttons.SetActive(true);
            }
        }
    }

    public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

    public void quit()
    {
        Application.Quit();
    }

}
