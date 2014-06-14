using UnityEngine;
using System.Collections;


public class C_player : MonoBehaviour {
	
	public Vector2 direction = new Vector2(1,0);
	public float maxSpeed = 2f;
	private Vector3 movement;
	Animator anim;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool grounded = false;
	public LayerMask whatIsGround;   
	
	//yang asli
	public bool jump;
	public float jumpForce = 15.0f; // Force added when the player jumps.
	private bool canJump = false;
	private int availableJumps = 2;
	private float sp = 1.7f;
	private float timelimit = 30.0f;

	public Vector2 lariotomatis(float addspedd)
	{
		movement = new Vector3(addspedd * maxSpeed * direction.x, rigidbody2D.velocity.y);
		return movement;	
	}
	
	void Start () {
		
		anim = GetComponent<Animator>();	
	}
	
	void Update () {
		
		//touch screen
		int fingercount = 0;
		
		foreach( Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				fingercount++;
			}
		}
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) || (fingercount > 0)) {
			
			jump = true;// I can jump				 
		}
		else{ jump = false;}
		//menambahkan kecepatan setiap 30 detik
		addspeed();
	}

	private void addspeed()
	{
		if((Time.time >= timelimit) && Time.time <= 330)
		{

			Debug.Log(" waktu = " + timelimit);        
			timelimit += 30.0f;   
			sp += 0.15f;
		}
		Debug.Log(" nilai sp " + sp);
		rigidbody2D.velocity = lariotomatis(sp); 
	}    

	//Update for physics steps. Regular intervals. 
	void FixedUpdate(){    
		
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);		
		anim.SetBool("Ground", grounded);
		if(grounded && jump && canJump)
		{			
			anim.SetBool("Ground", false);    
			rigidbody2D.velocity = new Vector2(0f,jumpForce);
			// Can the player jump again??
			availableJumps--;
			if (availableJumps <= 1 ){
				canJump = false;  
			}
			jump = false;
		}
		    
		//rigidbody2D.velocity = lariotomatis(sp);   
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(grounded == true){
			canJump = true;
			availableJumps = 2;
		}
	}
}
