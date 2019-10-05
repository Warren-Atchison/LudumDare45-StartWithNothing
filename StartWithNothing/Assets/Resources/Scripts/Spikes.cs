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
        Debug.Log("ur ded");
    }
}