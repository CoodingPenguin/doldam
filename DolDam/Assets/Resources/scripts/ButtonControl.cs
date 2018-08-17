using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour {

    public AudioClip leftButtonSound;
    public AudioClip rightButtonSound;
    public AudioClip startButtonSound;

    public void LeftButtonOnClicked()
    {
        SoundManager.instance.PlaySingleForBtn(leftButtonSound);
        SceneManager.LoadScene("Resources/scenes/DeveloperScene");
    }

    public void RightButtonOnClicked()
    {
        SoundManager.instance.PlaySingleForBtn(rightButtonSound);
        SceneManager.LoadScene("Resources/scenes/SetUpScene");

    }

    public void StartButtonOnClicked()
    {
        SoundManager.instance.bgmSource.Stop();
        SoundManager.instance.PlaySingleForBtn(startButtonSound);
        SceneManager.LoadScene("Resources/scenes/GameScene");
        GameManager.instance.gameState = GameManager.GameState.PLAYING;
    }
}