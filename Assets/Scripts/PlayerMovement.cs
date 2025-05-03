using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;
    public float jumpForce = 700.0f;
    public bool isGrounded;
    public float checkRadius = 0.2f;

    public LayerMask groundLayer;
    public Transform groundCheck;
    Rigidbody2D r2d;
    Animator anim;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            r2d.AddForce(new Vector2(0, jumpForce));
        }
        if(isGrounded)
        {
            anim.SetBool("Jump", false);
        }else
        {
            anim.SetBool("Jump", true);
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        if(move == 0)
        {
            anim.SetBool("Run", false);
        }
        else 
        {
            anim.SetBool("Run", true);
        }

        r2d.linearVelocity = new Vector2(move * maxSpeed, r2d.linearVelocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ถ้าชนกับวัตถุที่อยู่ใน Layer ชื่อว่า "Ground"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
}
