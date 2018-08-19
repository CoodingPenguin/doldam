using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffScript : MonoBehaviour {

    public GameObject turnOffPanel;
    public AudioClip btnSound;
	
	void Start () {
        turnOffPanel = GameObject.FindGameObjectWithTag("TurnOff");
        turnOffPanel.SetActive(false);
	}
	
	
	void Update () {
		if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                turnOffPanel.SetActive(true);
            }
        }
	}

    public void YesButtonOnClicked()
    {
        SoundManager.instance.PlaySingleForBtn(btnSound);
        Application.Quit();
    }

    public void NoButtonOnClicked()
    {
        SoundManager.instance.PlaySingleForBtn(btnSound);
        turnOffPanel.SetActive(false);
    }
}
