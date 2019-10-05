using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject menu;
    GameObject settings;

    void Awake()
    {
        menu = GameObject.Find("StartMenu");
        settings = GameObject.Find("SettingsMenu");
    }

    private void Start()
    {
        settings.SetActive(false);
        DontDestroyOnLoad(settings);
    }

    public void PlayButton()
    {
        // Causes the platform to fall out of the world.
        Rigidbody2D platform = GameObject.Find("Platform").GetComponent<Rigidbody2D>();
        platform.bodyType = RigidbodyType2D.Dynamic;
        platform.gravityScale = 4;

        
    }

    public void SettingsButton()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    } 
}
