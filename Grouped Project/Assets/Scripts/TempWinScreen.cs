using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempWinScreen : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("WinScreen");/*
        MenuMusic mmusic = FindObjectOfType<MenuMusic>();
        if (mmusic != null)
        {
            // Assign the object to the desired field
            MenuMusic yourComponent = GetComponent<MenuMusic>();
            if (yourComponent != null)
            {
                yourComponent.AudioManager = mmusic.AudioManager;
            }
        }*/
    }
}
