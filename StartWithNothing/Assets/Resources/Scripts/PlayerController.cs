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
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            ac.Play("Jump");
        }
    }

    private void Cheat()
    {
        Debug.Log("ADDING ALL KEYS TO OPTIONS! TEST SCENE ACTIVE!");

        if (!unlockedKeys.ContainsKey("Spacebar"))
            unlockedKeys.Add("Spacebar", KeyCode.Space);

        if (!unlockedKeys.ContainsKey("A"))
            unlockedKeys.Add("A", KeyCode.A);

        if (!unlockedKeys.ContainsKey("D"))
            unlockedKeys.Add("D", KeyCode.D);
    }

    private void OnBecameInvisible()
    {
        Die();
    }

    private void Die()
    {
        Debug.Log("YOU DONE DIED!");

        gameObject.transform.position = spawn;
        rb.velocity = Vector2.zero;
        ac.Play("Death");
    }
}
