using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float move;
    private bool activateJump = false;
    [SerializeField]private LayerMask GroundLayer;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpForce;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, 0.7f, GroundLayer))
            {
                activateJump = true;
            }
        }
        Debug.Log(move);
    }
}
