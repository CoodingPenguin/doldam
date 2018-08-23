using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public AudioSource efxSource;
    public AudioSource btnSource;
    public AudioSource bgmSource;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.PlayOneShot(clip);
    }

    public void PlaySingleForBtn(AudioClip clip)
    {
        btnSource.PlayOneShot(clip);
    }

    public void RandomizeSfx (params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;

        efxSource.PlayOneShot(clips[randomIndex]);
    }

    public void PlayBgm(AudioClip clip, bool loop = true)
    {
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }


}
