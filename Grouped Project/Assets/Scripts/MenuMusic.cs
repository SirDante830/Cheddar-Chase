using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;
    public AudioSource audioSource;
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

}
