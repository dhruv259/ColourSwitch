using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool gameOver = false;
    public bool gameReset = false;

    GameObject player;
    Vector2 spawnLocation;

    public GameObject gameOverCanvas;
    void Start()
    {
		// setup reference to game manager
		if (gm == null)
        {
			gm = this.GetComponent<GameManager>();
        }
		// setup all the variables, the UI, and provide errors if things not setup properly.
		setupDefaults();
	}

    void setupDefaults()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        gameOverCanvas.SetActive(false);

        spawnLocation = player.transform.position;

        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.touchCount > 0)
        {
            Time.timeScale = 1f;
        }
        
        if(gameReset)
        {
            ShowCanvas();
        }

        if(gameOver)
        {
            ShowCanvas();
        }
    }

    public void ShowCanvas()
    {
        player.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
