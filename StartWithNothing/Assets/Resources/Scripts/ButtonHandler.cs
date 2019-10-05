using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    GameObject menu;
    GameObject settings;
    AudioController audioController;
    GameObject musicSlider;
    GameObject sfxSlider;

    void Awake()
    {
        menu = GameObject.Find("Menu");
        settings = GameObject.Find("Settings");
        audioController = FindObjectOfType<AudioController>();
        musicSlider = GameObject.Find("MusicSlider");
        sfxSlider = GameObject.Find("SFXSlider");
    }

    private void Start()
    {
        settings.SetActive(false);
        DontDestroyOnLoad(settings);
        //DontDestroyOnLoad(this);
    }

    public void PlayButton()
    {
        Debug.Log("PLAY!");
    }

    public void SettingsButton()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.Equals("MainMenu"))
        {
            menu.SetActive(true);
            settings.SetActive(false);
        }
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
