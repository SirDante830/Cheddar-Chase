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
    public void Quit()
    {
        Application.Quit();
    }
}