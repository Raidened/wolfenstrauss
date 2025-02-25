using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private float move;
    private bool activateJump = false;
    public bool grounded;
    
    private bool isJumping = false;

    [SerializeField]private LayerMask GroundLayer;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpForce;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(move * moveSpeed, rb2d.velocity.y);
        
        if (activateJump)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            activateJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            activateJump = true;
            isJumping = true;
        }
        Debug.Log(move);
        SetAnim();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 normal = other.GetContact(0).normal;
            if (normal == Vector3.up)
            {
                grounded = true;
                isJumping = false;
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    void SetAnim()
    {
        if (isJumping)
        {
            anim.SetInteger("Dir", 2); // Animation de saut
        }
        else if (move == 0)
        {
            anim.SetInteger("Dir", 0); // Animation d'Idle
        }
        else if (move > 0)
        {
            anim.SetInteger("Dir", 1);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (move < 0)
        {
            anim.SetInteger("Dir", 1);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
