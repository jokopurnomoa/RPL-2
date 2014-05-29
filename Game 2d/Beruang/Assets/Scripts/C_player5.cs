using UnityEngine;
using System.Collections;


public class C_player5 : MonoBehaviour {

	public Vector2 direction = new Vector2(1,0);
	public float maxSpeed = 2f;
	private Vector2 movement;
	Animator anim;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool grounded = false;
	public LayerMask whatIsGround;   
	private float kecepatan = 0f;



	//yang asli
	public bool jump;
	float jumpForce = 0f; // Force added when the player jumps.
	public float firstJumpForce = 0f;
	public float secondJumpForce = 0f;

	private bool canJump = false;
	private int availableJumps = 2;

	public Vector2 lariotomatis()
	{
		movement = new Vector2(maxSpeed * direction.x, rigidbody2D.velocity.y);
		return movement;	
	}

	void Start () {
		
		anim = GetComponent<Animator>();	
	}
	
	void Update () {
		//grounded && Input.GetKeyDown(KeyCode.Space)
		Debug.Log("nilai x player" + transform.position.x);
		 if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))) {

			jump = true;// I can jump
			//Debug.Log(" jump true ");
		}
		else{ jump = false; }

		//tambah kecepatan otomatis
		Debug.Log("time " + Time.time);

	}
	
	//Update for physics steps. Regular intervals. 
	void FixedUpdate(){
		rigidbody2D.velocity = lariotomatis();
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
		//Debug.Log(" nilai grounded "+ grounded);

		if(jump && canJump)
		{
			// Add a vertical force to the player.

			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(600f, jumpForce));
			// Can the player jump again??
			availableJumps--;
			if (availableJumps <= 0 ){
				canJump = false;
			//	Debug.Log(" nilai canjump");
			} else {
				//I modify the second jump force
				jumpForce = secondJumpForce;
			//	Debug.Log("nilai jumforce"+ jumpForce);
			
			}
			jump = false;

		}


	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if(grounded == true)
		{
			//coll.gameObject.SendMessage(" hello gw di enter 2d");
			canJump = true;
			availableJumps = 2;
			jumpForce = firstJumpForce;
		}


	}
}
