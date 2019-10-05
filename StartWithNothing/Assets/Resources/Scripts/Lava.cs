using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            collision.gameObject.GetComponent<PlayerController>().Die();
        else
            Destroy(collision.gameObject);
    }
}
