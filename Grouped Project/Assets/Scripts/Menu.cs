using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public MenuMusic music;
    
    void Start()
    {
        music.AudioManager = GameObject.Find("AudioManager");
        print("printing start");
        music.GetComponent<MenuMusic>();
    }
    public void GameStart()
    {
        music.PlayGame();
        SceneManager.LoadScene("Level");
    }
        
    public void Keys()
    {
        SceneManager.LoadScene("Keys");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Title()
    {
        music.TitleMusic();
        SceneManager.LoadScene("MainMenu");
    }
    public void EndTItle()
    {
        music.EndTitle();
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}