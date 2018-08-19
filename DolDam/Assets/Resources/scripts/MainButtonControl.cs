using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonControl : MonoBehaviour {

    public AudioClip mainButtonSound;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SoundManager.instance.PlaySingleForBtn(mainButtonSound);
                SceneManager.LoadScene("Resources/scenes/StartScene");
            }
        }
    }

    public void ChangeGameScene()
    {
        SoundManager.instance.PlaySingleForBtn(mainButtonSound);
        SceneManager.LoadScene("Resources/scenes/StartScene");
    }
}
