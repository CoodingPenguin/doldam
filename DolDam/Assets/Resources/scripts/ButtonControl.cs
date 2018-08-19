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
        Debug.Log("시작화면 - 왼쪽 버튼");
        SoundManager.instance.PlaySingleForBtn(leftButtonSound);
        SceneManager.LoadScene("Resources/scenes/DeveloperScene");
    }

    public void RightButtonOnClicked()
    {
        Debug.Log("시작화면 - 오른쪽 버튼");
        SoundManager.instance.PlaySingleForBtn(rightButtonSound);
        SceneManager.LoadScene("Resources/scenes/SetUpScene");

    }

    public void StartButtonOnClicked()
    {
        Debug.Log("시작화면 - 시작 버튼");
        SoundManager.instance.bgmSource.Stop();
        SoundManager.instance.PlaySingleForBtn(startButtonSound);
        SceneManager.LoadScene("Resources/scenes/GameScene");
        GameManager.instance.gameState = GameManager.GameState.PLAYING;
    }

}