using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonControl : MonoBehaviour {

    public AudioClip mainButtonSound;

    public void ChangeGameScene()
    {
        SoundManager.instance.PlaySingleForBtn(mainButtonSound);
        SceneManager.LoadScene("Resources/scenes/StartScene");
    }
}
