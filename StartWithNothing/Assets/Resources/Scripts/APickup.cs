using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("YOU PICKED UP THE A KEY!");

            GameObject.Find("Player").GetComponent<PlayerController>().AddKey("A", KeyCode.A);
        }
    }
}
