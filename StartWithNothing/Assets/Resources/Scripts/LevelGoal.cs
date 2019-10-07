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

            if (newScene == sceneHandler.levels.Count)
            {
                sceneHandler.ChangeScenes(sceneHandler.levels[0]);
                sceneHandler.deathCounter.SetActive(false);
                return;
            }

            sceneHandler.ChangeScenes(sceneHandler.levels[newScene]);
        }
    }
}
