using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneHandler sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
        int newScene = sceneHandler.levels.IndexOf("Level1") + 1;

        Debug.Log("attempting to load " + sceneHandler.levels[newScene]);

        sceneHandler.ChangeScenes(sceneHandler.levels[newScene]);
    }
}
