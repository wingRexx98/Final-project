using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float runSpeed = 10f;
    bool isFacingRight = true;
    public float jumpForce = 700f;
    bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    float groundRadious = 0.2f;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Grounded", false);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadious, whatIsGround);
        anim.SetBool("Grounded", isGrounded);

        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("vSpeed", rb.velocity.y);
        if (move > 0 && !isFacingRight)
            Flip();
        if (move < 0 && isFacingRight)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
