using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpControl : MonoBehaviour {

    public Slider bgmSlider;
    public Slider efxSlider;

    public AudioClip exClip;

    void Start()
    {
        bgmSlider.value = (int)(SoundManager.instance.bgmSource.volume * 10);
        efxSlider.value = (int)(SoundManager.instance.efxSource.volume * 10);
    }

    public void BgmManage () {
        SoundManager.instance.bgmSource.volume = bgmSlider.value * 0.1f;
        SoundManager.instance.PlaySingle(exClip);
	}

    public void EfxManage()
    {
        SoundManager.instance.efxSource.volume = efxSlider.value * 0.1f;
        SoundManager.instance.PlaySingle(exClip);
    }

    public void ScoreInitialization()
    {
        SoundManager.instance.PlaySingleForBtn(exClip);
        PlayerPrefs.DeleteKey("BestScore");
    }
}
