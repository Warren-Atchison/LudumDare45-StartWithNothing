using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public List<string> levels;
    public static GameObject settingsMenu;

    public static Dictionary<string, KeyCode> playerKeys;

    private void Awake()
    {
        settingsMenu = GameObject.Find("SettingsMenu");
        playerKeys = new Dictionary<string, KeyCode>();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScenes(string newScene)
    {
        SceneManager.LoadScene(levels.IndexOf(newScene));
    }

    public void AddKey(string keyName)
    {
        if (keyName.Equals("Spacebar") && !playerKeys.ContainsKey("Spacebar"))
            playerKeys.Add("Spacebar", KeyCode.Space);

        if (keyName.Equals("A") && !playerKeys.ContainsKey("A"))
            playerKeys.Add("A", KeyCode.A);

        if (keyName.Equals("D") && !playerKeys.ContainsKey("D"))
            playerKeys.Add("D", KeyCode.D);
    }
}
