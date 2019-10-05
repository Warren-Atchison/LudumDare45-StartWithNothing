﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("YOU PICKED UP SPACEBAR!");

            GameObject.Find("Player").GetComponent<PlayerController>().AddKey("Spacebar", KeyCode.Space);
        }
    }
}
