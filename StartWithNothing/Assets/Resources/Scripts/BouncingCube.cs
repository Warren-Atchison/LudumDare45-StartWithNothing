using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingCube : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpPower;
    float targetMoveSpeed;

    public bool isGrounded;
    public LayerMask groundLayers;

    private void Update()
    {
        // isGrounded?
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y + 0.51f), groundLayers);

        targetMoveSpeed = Mathf.Lerp(rb.velocity.x, Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, Time.deltaTime * 10);
        rb.velocity = new Vector2(targetMoveSpeed, rb.velocity.y);

        if (isGrounded)
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.505f), new Vector2(1, 0.01f));
    }
}
