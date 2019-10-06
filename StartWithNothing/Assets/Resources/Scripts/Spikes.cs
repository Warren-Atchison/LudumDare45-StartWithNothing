using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private GameObject player;
    void Start(){
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name.Equals("Player"))
            collision.gameObject.GetComponent<PlayerController>().Die();
    }
}