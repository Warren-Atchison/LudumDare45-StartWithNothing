using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public List<string> levels;
    public static GameObject settingsMenu;

    private void Awake()
    {
        settingsMenu = GameObject.Find("SettingsMenu");
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScenes(string newScene)
    {
        SceneManager.LoadScene(levels.IndexOf(newScene));
    }
}
