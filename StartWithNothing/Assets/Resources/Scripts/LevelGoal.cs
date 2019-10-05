using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            SceneHandler sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
            int newScene = sceneHandler.levels.IndexOf(SceneManager.GetActiveScene().name) + 1;

            Debug.Log("attempting to load " + sceneHandler.levels[newScene]);

            sceneHandler.ChangeScenes(sceneHandler.levels[newScene]);
        }
    }
}
