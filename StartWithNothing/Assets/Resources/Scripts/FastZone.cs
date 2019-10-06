﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZone : MonoBehaviour
{
    private GameObject player;
    float defaultMoveSpeed;
    private PlayerController pc;
    private Rigidbody2D rb;

    void Start(){
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
        rb = player.GetComponent<Rigidbody2D>();

        defaultMoveSpeed = pc.moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        // Multiplies movespeed in the collision box by a constant
        pc.moveSpeed = defaultMoveSpeed*2;
    }

    private void OnTriggerExit2D(Collider2D collision){
        // Resets movespeed to default
        pc.moveSpeed = defaultMoveSpeed;
    }
}