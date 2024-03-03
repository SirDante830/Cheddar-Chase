using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public GameObject AudioManager;
    private static MenuMusic instance;
    public AudioSource audioSource;
    public string audioClipName = "TitleScreenCatnMouse";
    public AudioClip gameMusic;
    public AudioClip pauseMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioClip titleMusic;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
       
    }
    void Start()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + audioClipName);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            print("audioclipname: " + audioClipName);
            audioSource.Play();
        }
        else
        {
            print("Failed to load audio clip: " + audioClipName);
        }
    }

    public void PlayGame()
    {
        audioSource.Stop();
        audioSource.clip = gameMusic;
        audioSource.Play();
    }
    public void PauseMusic()
    {
        audioSource.Stop();
        audioSource.clip = pauseMusic;
        audioSource.Play();
    }
    public void WinMusic()
    {
        audioSource.Stop();
        audioSource.clip = winMusic;
        audioSource.Play();
    }
    public void LoseMusic()
    {
        audioSource.Stop();
        audioSource.clip = loseMusic;
        audioSource.Play();
    }
    public void TitleMusic()
    {
        audioSource.Stop();
        audioSource.clip = titleMusic;
        audioSource.Play();
    }
    public void EndTitle()
    {
        audioSource.Stop();
        audioSource.clip = titleMusic;
        audioSource.Play();
    }

}
