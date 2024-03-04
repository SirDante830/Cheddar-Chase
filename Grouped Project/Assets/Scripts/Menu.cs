using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GameStart()
    {
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
        SceneManager.LoadScene("MainMenu");
    }
    public void EndTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
        print("Quitting");
    }
}