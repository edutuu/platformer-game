using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float force = 5; 
    public float speed = 10; 
    private float horizontal;
    private float lockPos = 0;

    Rigidbody2D rb;
    private BoxCollider2D coli;

    
    private bool isJumping;

    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coli = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);

        if (Input.GetKey("space") && IsGrounded())
        {
            rb.velocity = Vector2.up * force;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

  
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coli.bounds.center, coli.bounds.size, 0f, Vector2.down, 0.1f, ground);

    }
}
