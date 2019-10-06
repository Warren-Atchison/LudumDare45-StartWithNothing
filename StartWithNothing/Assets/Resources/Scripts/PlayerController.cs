﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public bool isGrounded, inWater = false;
    public int airJumpCharges = 1;
    public LayerMask groundLayers;
    private Rigidbody2D rb;
    public Dictionary<string, KeyCode> unlockedKeys;

    AudioController ac;
    Vector3 spawn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ac = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("TestScene"))
        {
            unlockedKeys = new Dictionary<string, KeyCode>();
            Cheat();
        }
        else
            unlockedKeys = SceneHandler.playerKeys;

        spawn = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y + 0.51f), groundLayers);
        if(isGrounded){
            airJumpCharges = 1;
        }

        if (unlockedKeys.ContainsKey("GroundJump") && Input.GetKeyDown(KeyCode.Space))
            GroundJump();

        if(unlockedKeys.ContainsKey("AirJump") && Input.GetKeyDown(KeyCode.Space))
            AirJump();

        if ((unlockedKeys.ContainsKey("A") && Input.GetKey(KeyCode.A)) || (unlockedKeys.ContainsKey("D") && Input.GetKey(KeyCode.D)))
            rb.velocity = computeVelocity(Input.GetAxis("Horizontal"));

        CheckBoundaries();
    }

    public void AddKey(string keyName, KeyCode key)
    {
        unlockedKeys.Add(keyName, key);
    }

    Vector2 computeVelocity(float axis = 0f)
    {
        Vector2 move = rb.velocity;

        move.x = axis;
        move.x *= moveSpeed;

        return move;
    }

    private void GroundJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            ac.Play("Jump");
        }
    }

    private void AirJump(){
        if(inWater){
            return;
        }
        if (!isGrounded){
            if(airJumpCharges > 0){
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                ac.Play("Jump");
                airJumpCharges--;
            }
        }
    }

    private void Cheat()
    {
        Debug.Log("ADDING ALL KEYS TO OPTIONS! TEST SCENE ACTIVE!");

        if (!unlockedKeys.ContainsKey("GroundJump"))
            unlockedKeys.Add("GroundJump", KeyCode.Space);

        if (!unlockedKeys.ContainsKey("AirJump"))
            unlockedKeys.Add("AirJump", KeyCode.Space);

        if (!unlockedKeys.ContainsKey("Swim"))
            unlockedKeys.Add("Swim", KeyCode.Space);

        if (!unlockedKeys.ContainsKey("A"))
            unlockedKeys.Add("A", KeyCode.A);

        if (!unlockedKeys.ContainsKey("D"))
            unlockedKeys.Add("D", KeyCode.D);
    }

    private void CheckBoundaries()
    {
        Vector3 worldView = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        if (gameObject.transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y ||
            gameObject.transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)).y)
            Wraparound('y');
        if (gameObject.transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x ||
                 gameObject.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)).x)
            Wraparound('x');
    }

    public void Die(string clipString = "Death")
    {
        gameObject.transform.position = spawn;
        rb.velocity = Vector2.zero;
        ac.Play(clipString);
    }

    private void Wraparound(char toggle)
    {
        if(toggle == 'x')
            gameObject.transform.position = new Vector3(-gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        if (toggle == 'y')
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -gameObject.transform.position.y, 0f);
    }
}
