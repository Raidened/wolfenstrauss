using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyChase : MonoBehaviour
{
	public GameObject Player;
	public GameObject PointA;
	public GameObject PointB;

	private Rigidbody2D rb2d;
    private Animator anim;
	private Transform currentPoint;
	private float distance; 
    private float move;
	public float moveSpeed;

	public int damage;

	private bool isAttacking = false;
	private float lastAttackTime = 0f;
	public float attackCooldown = 2f;

	public float attackAnimationTime = 0.5f;
	private PlayerHealth playerHealth;

    // Awake is called before the 

	void Awake()
    {	
		playerHealth = Player.GetComponent<PlayerHealth>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		currentPoint = PointB.transform;
		anim.SetInteger("Dir", 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		if (isAttacking) return;
		
		if (Vector2.Distance(transform.position, Player.transform.position) > 6)
		{	
			anim.SetInteger("Dir", 0);
			Vector2 Point = currentPoint.position - transform.position;
			if (currentPoint == PointB.transform)
			{
				rb2d.velocity = new Vector2(3, 0);
			}
			else 
			{
				rb2d.velocity = new Vector2(-3, 0);
			}

			if (Vector2.Distance(transform.position, currentPoint.position) < 1.2f  && currentPoint == PointB.transform)
			{
				currentPoint = PointA.transform;				
			}

			if (Vector2.Distance(transform.position, currentPoint.position) < 1.2f  && currentPoint == PointA.transform)
			{	
				currentPoint = PointB.transform;	
			}
		}

		else if (Vector2.Distance(transform.position, Player.transform.position) <= 6)
		{	
			
			transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
			
			if (Vector2.Distance(transform.position, Player.transform.position) <= 2f)
			{	
				if (Time.time >= lastAttackTime + attackCooldown)
				{
					StartCoroutine(Attack());
				}
			}
		}
    }

	IEnumerator Attack()
    {
        isAttacking = true;
        anim.SetInteger("Dir", 1);
        playerHealth.TakeDamage(damage);
        lastAttackTime = Time.time;

        Debug.Log("Enemy hit the player!");

        yield return new WaitForSeconds(attackAnimationTime);

        anim.SetInteger("Dir", 0);
        isAttacking = false;
    }
}
