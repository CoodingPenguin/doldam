using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    
    public enum GameState
    {
        MENU,START,PLAYING,PAUSED
    };

    private float scrollSpeed = 10f;
    private float maxSpeed = 30f;
    public GameState gameState;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        gameState = GameState.MENU;
        gameState = GameState.PLAYING;
        
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
        if (gameState != GameState.PAUSED)
            gameState = GameState.PAUSED;
        else if (gameState == GameState.PAUSED)
            gameState = GameState.PLAYING;
    }
}
