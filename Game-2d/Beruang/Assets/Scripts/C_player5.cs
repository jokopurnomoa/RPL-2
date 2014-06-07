using UnityEngine;
using System.Collections;


public class C_player5 : MonoBehaviour {
	
	public Vector2 direction = new Vector2(1,0);
	public float maxSpeed = 2f;
	private Vector3 movement;
	Animator anim;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool grounded = false;
	public LayerMask whatIsGround;   
	private float kecepatan = 0f;
	
	//yang asli
	public bool jump;
	float jumpForce = 0f; // Force added when the player jumps.
	public float firstJumpForce = 12f;
	public float secondJumpForce = 15f;
	
	private bool canJump = false;
	private int availableJumps = 2;
	private float sp = 1.2f;
	
	public Vector2 lariotomatis(float addspedd)
	{
		movement = new Vector3(addspedd * maxSpeed * direction.x, rigidbody2D.velocity.y);
		return movement;	
	}
	
	void Start () {
		
		anim = GetComponent<Animator>();	
	}
	

	
	//Update for physics steps. Regular intervals. 
	void FixedUpdate(){
		
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);		
		anim.SetBool("Ground", grounded);
		if(jump && canJump)
		{
			// Add a vertical force to the player.    			
			anim.SetBool("Ground", false);    
			//rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			rigidbody2D.velocity = new Vector2(0f,15f);
			Debug.Log(" nilai sp " + sp);
			// Can the player jump again??
			availableJumps--;
			if (availableJumps <= 0 ){
				canJump = false;  
				//sp = 1f;
			} else {
				//I modify the second jump force
				jumpForce = secondJumpForce;
				  
			}
			jump = false;
			sp = 1.7f; 
		}
		//Debug.Log(" nilai spc " + sp);
		rigidbody2D.velocity = lariotomatis(1f); 
	}

	void Update () {
		
		//touch screen
		int fingercount = 0;
		
		foreach( Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				fingercount++;
			}
		}
		if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) || (fingercount > 0)) {
			
			jump = true;// I can jump				 
		}
		else{ jump = false;
			   
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if(grounded == true){
			//coll.gameObject.SendMessage(" hello gw di enter 2d");
			canJump = true;
			availableJumps = 2;
			sp = 1f;
			jumpForce = firstJumpForce;
		}
	}
}
