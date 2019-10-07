using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public List<int> levelsWithKeys;
    public List<string> keysForLevels;

    private static int pageNumber;

    GameObject startMenu;
    GameObject levelSelectMenu;

    AudioController audioController;

    public GameObject topLeftButton;
    public GameObject topRightButton;
    public GameObject bottomLeftButton;
    public GameObject bottomRightButton;

    public GameObject topLeftBlack;
    public GameObject topRightBlack;
    public GameObject bottomLeftBlack;
    public GameObject bottomRightBlack;

    public GameObject leftArrow;
    public GameObject rightArrow;

    private static Sprite[] levelPics;
    private static Sprite[] keys; 

    void Awake()
    {
        audioController = FindObjectOfType<AudioController>();

        pageNumber = 1;

        startMenu = GameObject.Find("StartMenu");
        levelSelectMenu = GameObject.Find("LevelSelectMenu");
    }

    private void Start()
    {
        if (!gameObject.name.Equals("LevelSelectMenu"))
            return;

        levelPics = Resources.LoadAll<Sprite>("Sprites/Levels/");
        keys = Resources.LoadAll<Sprite>("Sprites/KeysForLevels/");

        leftArrow.SetActive(false);
    }

    public void RightArrow()
    {
        pageNumber++;

        if (pageNumber * 4 > levelPics.Length - 1)
            rightArrow.SetActive(false);

        if (!leftArrow.activeInHierarchy)
            leftArrow.SetActive(true);

        SetLevel((pageNumber * 4) - 4);
        SetLevel((pageNumber * 4) - 3);
        SetLevel((pageNumber * 4) - 2);
        SetLevel((pageNumber * 4) - 1);
    }

    public void LeftArrow()
    {
        pageNumber--;

        if (pageNumber == 1)
            leftArrow.SetActive(false);

        if (!rightArrow.activeInHierarchy)
            rightArrow.SetActive(true);

        SetLevel((pageNumber * 4) - 4);
        SetLevel((pageNumber * 4) - 3);
        SetLevel((pageNumber * 4) - 2);
        SetLevel((pageNumber * 4) - 1);
    }

    private void SetLevel(int levelNum)
    {
        if (levelNum >= levelPics.Length)
        {
            // Topleft
            if (levelNum % 4 == 0)
            {
                topLeftButton.SetActive(false);
                topLeftBlack.SetActive(false);
            }

            // Topright
            else if (levelNum % 4 == 1)
            {
                topRightButton.SetActive(false);
                topRightBlack.SetActive(false);
            }

            // Bottomleft
            else if (levelNum % 4 == 2)
            {
                bottomLeftButton.SetActive(false);
                bottomLeftBlack.SetActive(false);
            }

            // Bottomright
            else if (levelNum % 4 == 3)
            {
                bottomRightButton.SetActive(false);
                bottomRightBlack.SetActive(false);
            }

            return;
        }

        // Topleft
        if (levelNum % 4 == 0)
        {
            topLeftButton.SetActive(true);
            topLeftBlack.SetActive(true);

            topLeftButton.GetComponentInChildren<Text>().text = "Level " + (levelNum + 1);
            topLeftButton.GetComponent<Image>().sprite = levelPics[levelNum];
            topLeftButton.transform.GetChild(1).GetComponent<Image>().sprite = keys[levelNum];
        }

        // Topright
        if (levelNum % 4 == 1)
        {
            topRightButton.SetActive(true);
            topRightBlack.SetActive(true);

            topRightButton.GetComponentInChildren<Text>().text = "Level " + (levelNum + 1);
            topRightButton.GetComponent<Image>().sprite = levelPics[levelNum];
            topRightButton.transform.GetChild(1).GetComponent<Image>().sprite = keys[levelNum];
        }

        // Bottomleft
        if (levelNum % 4 == 2)
        {
            bottomLeftButton.SetActive(true);
            bottomLeftBlack.SetActive(true);

            bottomLeftButton.GetComponentInChildren<Text>().text = "Level " + (levelNum + 1);
            bottomLeftButton.GetComponent<Image>().sprite = levelPics[levelNum];
            bottomLeftButton.transform.GetChild(1).GetComponent<Image>().sprite = keys[levelNum];

        }

        // Bottomright
        if (levelNum % 4 == 3)
        {
            bottomRightButton.SetActive(true);
            bottomRightBlack.SetActive(true);

            bottomRightButton.GetComponentInChildren<Text>().text = "Level " + (levelNum + 1);
            bottomRightButton.GetComponent<Image>().sprite = levelPics[levelNum];
            bottomRightButton.transform.GetChild(1).GetComponent<Image>().sprite = keys[levelNum];
        }
    }

    public void TopLeftLevel()
    {
        int selectedLevel = (pageNumber * 4) - 3;

        Debug.Log("selectedLevel = " + selectedLevel + " = (" + pageNumber + " * 4) - 3)");

        for (int i = 0; i < levelsWithKeys.Count; i++)
            if (levelsWithKeys[i] < selectedLevel)
                GameObject.Find("SceneHandler").GetComponent<SceneHandler>().AddKey(keysForLevels[i]);

        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScenes("Level" + selectedLevel);
    }

    public void TopRightLevel()
    {
        int selectedLevel = (pageNumber * 4) - 2;

        for (int i = 0; i < levelsWithKeys.Count; i++)
            if (levelsWithKeys[i] < selectedLevel)
                GameObject.Find("SceneHandler").GetComponent<SceneHandler>().AddKey(keysForLevels[i]);

        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScenes("Level" + selectedLevel);
    }

    public void BottomLeftLevel()
    {
        int selectedLevel = (pageNumber * 4) - 1;

        for (int i = 0; i < levelsWithKeys.Count; i++)
            if (levelsWithKeys[i] < selectedLevel)
                GameObject.Find("SceneHandler").GetComponent<SceneHandler>().AddKey(keysForLevels[i]);

        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScenes("Level" + selectedLevel);
    }

    public void BottomRightLevel()
    {
        int selectedLevel = (pageNumber * 4);

        for (int i = 0; i < levelsWithKeys.Count; i++)
            if (levelsWithKeys[i] < selectedLevel)
                GameObject.Find("SceneHandler").GetComponent<SceneHandler>().AddKey(keysForLevels[i]);

        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScenes("Level" + selectedLevel);
    }

    public void BackButton()
    {
        startMenu.SetActive(true);
        levelSelectMenu.SetActive(false);
    }
}
