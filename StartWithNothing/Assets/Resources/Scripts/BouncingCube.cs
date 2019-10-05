using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingCube : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpPower;

    public bool isGrounded;
    public LayerMask groundLayers;

    private void Update()
    {
        // isGrounded?
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y + 0.51f), groundLayers);

        if (isGrounded)
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
