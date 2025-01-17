﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    static GameObject menu;
    static GameObject settings;
    static GameObject levelSelect;
    static GameObject credits;

    GameObject bouncingCube;

    void Awake()
    {
        menu = GameObject.Find("StartMenu");
        settings = GameObject.Find("SettingsMenu");
        levelSelect = GameObject.Find("LevelSelectMenu");
        credits = GameObject.Find("CreditsMenu");

        bouncingCube = GameObject.Find("BouncingCube");
    }

    private void Start()
    {
        settings.SetActive(false);
        levelSelect.SetActive(false);
        credits.SetActive(false);
    }

    public void PlayButton()
    {
        // Causes the platform to fall out of the world.
        Rigidbody2D platform = GameObject.Find("Platform").GetComponent<Rigidbody2D>();
        platform.bodyType = RigidbodyType2D.Dynamic;
        platform.gravityScale = 4;
    }

    public static void StartGame()
    {
        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScenes("Level1");
    }

    public void LevelSelectButton()
    {
        levelSelect.SetActive(true);
        menu.SetActive(false);
    }

    public void SettingsButton()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void ExitButton()
    {
        bouncingCube.GetComponent<Rigidbody2D>().gravityScale = 10;
        bouncingCube.GetComponent<BouncingCube>().jumpPower = 100;
        bouncingCube.GetComponent<SpriteRenderer>().color = new Color(1f, 0.3725f, 0.3725f, 1f);
        StartCoroutine("Exit");
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.8f);
        Application.Quit();
    }

    public void CreditsButton()
    {
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void CreditsBackButton()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }
}
