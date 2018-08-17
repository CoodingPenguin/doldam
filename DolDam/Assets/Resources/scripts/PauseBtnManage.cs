﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBtnManage : MonoBehaviour {

    public GameObject panel;

    public AudioClip btnClicked;
    public AudioClip startBgm;

    public void Resume()
    {
        SoundManager.instance.bgmSource.Play();
        SoundManager.instance.PlaySingleForBtn(btnClicked);
        GameManager.instance.gameState = GameManager.GameState.PLAYING;
        panel.SetActive(false);
    }
   
    public void Restart()
    {
        SoundManager.instance.PlaySingleForBtn(btnClicked);
        SceneManager.LoadScene("Resources/scenes/GameScene");
        GameManager.instance.gameState = GameManager.GameState.PLAYING;
        panel.SetActive(false);
    }

    public void MainMenu()
    {
        SoundManager.instance.PlaySingleForBtn(btnClicked);
        SoundManager.instance.PlayBgm(startBgm, true);
        SceneManager.LoadScene("Resources/scenes/StartScene");
        panel.SetActive(false);
    }
   
}
