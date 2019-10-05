using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public bool isGrounded;
    public LayerMask groundLayers;
    private Rigidbody2D rb;
    Dictionary<string, KeyCode> unlockedKeys;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        unlockedKeys = SceneHandler.playerKeys;
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockedKeys.ContainsKey("Spacebar") && Input.GetKeyDown(KeyCode.Space))
            Jump();

        if ((unlockedKeys.ContainsKey("A") && Input.GetKey(KeyCode.A)) || (unlockedKeys.ContainsKey("D") && Input.GetKey(KeyCode.D)))
            rb.velocity = computeVelocity(Input.GetAxis("Horizontal"));

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

    private void Jump()
    {
        // isGrounded?
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y + 0.51f), groundLayers);

        if (isGrounded)
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        
    }
}
