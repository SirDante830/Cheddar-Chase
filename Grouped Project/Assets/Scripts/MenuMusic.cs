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
            //DontDestroyOnLoad(transform.gameObject);
        }
       
    }
    void Start()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + audioClipName);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
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
        audioClipName = "Gameplay HAAZAH";
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + audioClipName);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            print("Failed to load audio clip: " + audioClipName);
        }
    }
    public void PauseMusic()
    {
        audioSource.Stop();
        audioClipName = "EDITPauseControlMusic";
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + audioClipName);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            print("Failed to load audio clip: " + audioClipName);
        }
    }
    public void WinMusic()
    {
        audioSource.Stop();
        audioClipName = "WinSong";
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + audioClipName);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            print("Failed to load audio clip: " + audioClipName);
        }
    }
    public void LoseMusic()
    {
        audioSource.Stop();
        audioClipName = "LoseScreen";
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + audioClipName);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            print("Failed to load audio clip: " + audioClipName);
        }
    }
    public void TitleMusic()
    {
        audioSource.Stop();
        audioClipName = "TitleScreenCatnMouse";
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + audioClipName);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            print("Failed to load audio clip: " + audioClipName);
        }
    }

}
