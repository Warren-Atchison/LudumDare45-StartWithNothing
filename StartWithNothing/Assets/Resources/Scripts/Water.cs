using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private GameObject player;
    float defaultMoveSpeed, defaultJumpPower;
    private PlayerController pc;
    private Rigidbody2D rb;

    void Start(){
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
        rb = player.GetComponent<Rigidbody2D>();
        defaultMoveSpeed = pc.moveSpeed;
        defaultJumpPower = pc.jumpPower;
    }

    void Update(){
        if(pc.inWater && !pc.isGrounded){
            if(pc.unlockedKeys.ContainsKey("Swim") && Input.GetKeyDown(KeyCode.Space)){
                // If falling downwards
                if(rb.velocity.y < 0){
                    rb.AddForce(Vector2.up * defaultJumpPower * .2f, ForceMode2D.Impulse);
                }
                // If moving upwards
                else{
                    rb.AddForce(Vector2.up * defaultJumpPower * .1f, ForceMode2D.Impulse);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        pc.inWater = true;
        rb.gravityScale = .2f;
        rb.velocity *= .5f;
        pc.jumpPower = defaultJumpPower/3;
        pc.moveSpeed = defaultMoveSpeed/2;
    } 

    private void OnTriggerExit2D(Collider2D collision){
        pc.inWater = false;
        rb.gravityScale = 2;
        pc.jumpPower = defaultJumpPower;
        pc.moveSpeed = defaultMoveSpeed;
    }
}