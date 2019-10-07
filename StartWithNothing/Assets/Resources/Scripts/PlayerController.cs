using System.Collections;
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

        if (unlockedKeys.ContainsKey("A") && Input.GetKey(KeyCode.A))
            rb.velocity = computeVelocity(-1f);
        if (unlockedKeys.ContainsKey("D") && Input.GetKey(KeyCode.D))
            rb.velocity = computeVelocity(1f);

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
                rb.velocity = new Vector2(rb.velocity.x, 0f);
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

        // if (!unlockedKeys.ContainsKey("AirJump"))
        //     unlockedKeys.Add("AirJump", KeyCode.Space);

        // if (!unlockedKeys.ContainsKey("Swim"))
        //     unlockedKeys.Add("Swim", KeyCode.Space);

        if (!unlockedKeys.ContainsKey("A"))
            unlockedKeys.Add("A", KeyCode.A);

        if (!unlockedKeys.ContainsKey("D"))
            unlockedKeys.Add("D", KeyCode.D);
    }

    public void Die(string clipString = "Death")
    {
        SceneHandler.deaths++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        rb.velocity = Vector2.zero;
        ac.Play(clipString);
    }
}
