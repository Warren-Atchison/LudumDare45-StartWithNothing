using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("YOU PICKED UP THE D KEY!");

            GameObject.Find("Player").GetComponent<PlayerController>().AddKey("D", KeyCode.D);
        }
    }
}
