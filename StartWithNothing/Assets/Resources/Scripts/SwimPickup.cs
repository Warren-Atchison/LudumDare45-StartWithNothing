using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("YOU PICKED UP AIR JUMP!");

            GameObject.Find("Player").GetComponent<PlayerController>().AddKey("Swim", KeyCode.Space);
        }
    }
}
