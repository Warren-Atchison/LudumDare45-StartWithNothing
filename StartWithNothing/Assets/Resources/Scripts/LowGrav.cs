using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGrav : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision){
        collision.GetComponent<Rigidbody2D>().gravityScale /= 2;
    }

    private void OnTriggerExit2D(Collider2D collision){
        collision.GetComponent<Rigidbody2D>().gravityScale = .5f;
    }
}
