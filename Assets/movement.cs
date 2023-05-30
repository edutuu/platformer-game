using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float force = 3; 
    public float speed = 10; 
    private float horizontal = 0;
    private float lockPos = 0;
    
    private Rigidbody2D rb;
    private BoxCollider2D coli;
    private Animator anim;
    private SpriteRenderer sprite;
    public LayerMask ground;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coli = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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


        update_animation();
    }
            
    private void update_animation()
    {
        if (horizontal < 0)
        {
            anim.SetBool("is_running", true);
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            anim.SetBool("is_running", true);
            sprite.flipX = false;
        }
        else
        {
            anim.SetBool("is_running", false);
        }

        if (rb.velocity.y > .001f)
        {
            anim.SetBool("is_jumping", true);
        }
        else
        {
            anim.SetBool("is_jumping", false);
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
