using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiPlayerController : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        gameObject.transform.position = new Vector3(-player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
}
