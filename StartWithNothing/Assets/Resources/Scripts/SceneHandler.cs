using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public List<string> levels;
    public static GameObject settingsMenu;
    public GameObject deathCounter;
    public static int deaths;

    public static Dictionary<string, KeyCode> playerKeys;

    private void Awake()
    {
        settingsMenu = GameObject.Find("SettingsMenu");
        playerKeys = new Dictionary<string, KeyCode>();
    }

    private void Start()
    {
        DontDestroyOnLoad(GameObject.Find("DeathCounter"));
        DontDestroyOnLoad(gameObject);
        deathCounter.SetActive(false);
    }

    private void Update()
    {
        deathCounter.GetComponent<Text>().text = deaths.ToString() + "    ";
    }

    public void ChangeScenes(string newScene)
    {
        deathCounter.SetActive(true);
        SceneManager.LoadScene(levels.IndexOf(newScene));
    }

    public void AddKey(string keyName)
    {
        if (keyName.Equals("GroundJump") && !playerKeys.ContainsKey("GroundJump"))
            playerKeys.Add("GroundJump", KeyCode.Space);

        if (keyName.Equals("AirJump") && !playerKeys.ContainsKey("AirJump"))
            playerKeys.Add("AirJump", KeyCode.Space);

        if (keyName.Equals("Swim") && !playerKeys.ContainsKey("Swim"))
            playerKeys.Add("Swim", KeyCode.Space);

        if (keyName.Equals("A") && !playerKeys.ContainsKey("A"))
            playerKeys.Add("A", KeyCode.A);

        if (keyName.Equals("D") && !playerKeys.ContainsKey("D"))
            playerKeys.Add("D", KeyCode.D);
    }
}
