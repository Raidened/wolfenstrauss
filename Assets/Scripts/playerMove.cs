using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private float move;
    
    public bool grounded;
    private bool activateJump = false;
    
    // private bool canDash = true;
    // private bool isDashing = false;
    // private float dashForce = 20f; 
    // private float dashTime = 0.2f;
    // private float dashCooldown = 2f;

    [SerializeField]private LayerMask GroundLayer;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpForce;
    [SerializeField]private TrailRenderer trail;

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

        grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, GroundLayer);
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            activateJump = true;
        }
        Debug.Log(move);
        SetAnim();
    }

    void SetAnim()
    {
        if (!grounded)
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

    // private IEnumerator Dash()
    // {
    //     canDash = false;
    //     isDashing = true;
    //     float originalGravity = rb2d.gravityScale;
    //     rb2d.gravityScale = 0f;
    //     rb2d.velocity = new Vector2(move * dashForce, 0f);
    //     yield return new WaitForSeconds(dashTime);
    // }

}
