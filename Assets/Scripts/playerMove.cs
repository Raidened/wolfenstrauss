using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private float move;
    
    public bool grounded;
    private bool activateJump = false;
    
    private bool canDash = true;
    private bool isDashing;
    private float dashForce = -40f; 
    private float dashTime = 0.1f;
    private float dashCooldown = 1f;
    
    [SerializeField]private LayerMask GroundLayer;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpForce;
    [SerializeField]private TrailRenderer trail;

	[SerializeField]private string nextScene;
    public GameObject PointNextLevel;
    public GameObject PointTP;

    
    
    // Awake is called before the 
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
		SceneManager.LoadScene("Menu");
		}

        if (isDashing)
        {
            return;
        }
        move = Input.GetAxis("Horizontal");

        grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, GroundLayer);
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)  // Activate Jump with 'Space' when on ground
        {
            activateJump = true;
        }
        Debug.Log(move);
        SetAnim();

        if (Input.GetKeyDown(KeyCode.S) && canDash)  // Activate Dash with 'S' when can Dash
        {
            StartCoroutine(Dash());
        }

		if (Vector2.Distance(transform.position, PointNextLevel.transform.position) <= 1f)
        {
            SceneManager.LoadScene(nextScene);
        }

		if (Vector2.Distance(transform.position, PointTP.transform.position) <= 2f)
        {
            transform.position = new Vector3(5.7f, 8.25f, 0f);
        }
		
    }
    
    // FixedUpdate is called once each two frames
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb2d.velocity = new Vector2(move * moveSpeed, rb2d.velocity.y);
        
        if (activateJump)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            activateJump = false; 
        }
    }
    
    // Animation
    void SetAnim()
    {
        if (!grounded)
        {
            anim.SetInteger("Dir", 2); // Jump Animation
        }
        else if (move == 0)
        {
            anim.SetInteger("Dir", 0); // Idle Animation
        }
        
        else if (move > 0)
        {
            anim.SetInteger("Dir", 1);
            GetComponent<SpriteRenderer>().flipX = false; // Run Animation right
        }
        else if (move < 0)
        {
            anim.SetInteger("Dir", 1);
            GetComponent<SpriteRenderer>().flipX = true; // Run Animation left
        }
    }
    
    // Dash
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb2d.gravityScale;
        rb2d.gravityScale = 0f;
        rb2d.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        trail.emitting = true;
        yield return new WaitForSeconds(dashTime);
        trail.emitting = false;
        rb2d.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}