using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    
    public enum GameState
    {
        MENU,START,PLAYING,PAUSED
    };
    public enum TestEnvironment
    {
        PC,MOBILE
    }

    public int feverState = 0;
    

    private float scrollSpeed = 10f;
    private float maxSpeed = 100f;
    public GameState gameState;
    public TestEnvironment testEnvironment;

    public AudioClip pauseSound1;
    public AudioClip pauseSound2;

    public GameObject panel;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        gameState = GameState.MENU;
        gameState = GameState.PLAYING;

        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }
    public bool SetScrollSpeed(float spd)
    {
        if (spd > maxSpeed)
            return false;
        if (spd < 0)
            return false;
        scrollSpeed = spd;
        return true;
    }

    public void PauseButtonTouched()
    {
        if (gameState != GameState.PAUSED) {
            SoundManager.instance.bgmSource.Pause();
            SoundManager.instance.PlaySingleForBtn(pauseSound1);
            gameState = GameState.PAUSED;
            panel.SetActive(true);
        }
        else if (gameState == GameState.PAUSED)
        {
            SoundManager.instance.bgmSource.Play();
            SoundManager.instance.PlaySingleForBtn(pauseSound2);
            gameState = GameState.PLAYING;
            panel.SetActive(false);
        }
            
    }
}
