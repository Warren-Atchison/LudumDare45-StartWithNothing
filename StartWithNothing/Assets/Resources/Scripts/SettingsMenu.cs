using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    GameObject startMenu;
    GameObject settingsMenu;

    AudioController audioController;
    GameObject musicSlider;
    GameObject sfxSlider;

    void Awake()
    {
        audioController = FindObjectOfType<AudioController>();
        musicSlider = GameObject.Find("MusicSlider");
        sfxSlider = GameObject.Find("SFXSlider");

        startMenu = GameObject.Find("StartMenu");
        settingsMenu = GameObject.Find("SettingsMenu");
    }

    public void BackButton()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.Equals("MainMenu"))
        {
            startMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
        else
            settingsMenu.SetActive(false);
    }

    public void MusicSlider()
    {
        float sliderVal = musicSlider.GetComponent<Slider>().value;
        audioController.musicSource.volume = sliderVal;
        GameObject.Find("MusicPercent").GetComponent<Text>().text = System.Convert.ToInt32(sliderVal * 100) + "%";
    }

    public void SFXSlider()
    {
        float sliderVal = sfxSlider.GetComponent<Slider>().value;
        audioController.sfxSource.volume = sliderVal;
        GameObject.Find("SFXPercent").GetComponent<Text>().text = System.Convert.ToInt32(sliderVal * 100) + "%";
    }

    public void SFXSliderConfirm()
    {
        audioController.Play("Jump");
    }
}
