using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundJumpPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("YOU PICKED UP GROUND JUMP!");

            GameObject.Find("Player").GetComponent<PlayerController>().AddKey("GroundJump", KeyCode.Space);
        }
    }
}
