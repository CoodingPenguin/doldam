using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public GameObject pausePanel;
    public GameObject gameOverPanel;

    public int score;
    public Text scoreText;

	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
            gameState = GameState.MENU;
            gameState = GameState.PLAYING;
            pausePanel = null;
            gameOverPanel = null;
            score = 0;
        }
        else if (instance != this)
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
        
	}

    
    void Update()
    {
        if (pausePanel == null)
        {
            pausePanel = GameObject.FindGameObjectWithTag("panel");
            gameOverPanel = GameObject.FindGameObjectWithTag("gameOver");
            pausePanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }
    }

    public void AddScore(int plus)
    {
        score += plus;
        scoreText.text = score.ToString();
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
            pausePanel.SetActive(true);
        }
        else if (gameState == GameState.PAUSED)
        {
            SoundManager.instance.bgmSource.Play();
            SoundManager.instance.PlaySingleForBtn(pauseSound2);
            gameState = GameState.PLAYING;
            pausePanel.SetActive(false);
        }
            
    }

}
