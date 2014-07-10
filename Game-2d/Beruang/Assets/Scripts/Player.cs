using UnityEngine;
using System.Collections;
    

public class Player : MonoBehaviour {

	public float maxSpeed = 2f;
	private Vector3 movement;
	Animator anim;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	bool grounded = false;
	public LayerMask whatIsGround;     
	private bool cekplayer = true;
	private bool animdouble = false;   
	
	//yang asli
	public bool jump;
	public float jumpForce = 700f; // Force added when the player jumps.
	private bool canJump = false;
	private int availableJumps = 2;
	public float speed = 1.7f;
	private float timelimit = 30.0f;  
	private SoundOnOff buttonsound;
	
	public Vector3 Autorun(float addspedd)  
	{
		movement = new Vector3(addspedd * maxSpeed, rigidbody2D.velocity.y);
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
		if(cekplayer)
		{
			if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) || (fingercount > 0)) {
				jump = true;// I can jump			
			}
			else{ jump = false;}
			//menambahkan kecepatan setiap 30 detik
			Addspeed();
		}
	}   
	private void Addspeed()
	{
		if(( Time.timeSinceLevelLoad >= timelimit) && Time.timeSinceLevelLoad <= 330)
		{
			timelimit += 30.0f;   
			speed += 0.15f;   
		}
		rigidbody2D.velocity = Autorun(speed); 
	}  
	//Update for physics steps. Regular intervals. 
	void FixedUpdate(){         
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);		
		anim.SetBool("Ground", grounded); 	    
		//sound music player
		//SoundEffectHelper.Instance.MakePlayerSound();
		if(grounded){
			canJump = true;
			availableJumps = 2; 
		}   
		if(jump && canJump && !SoundOnOff.onoff)    
		{	
			anim.SetBool("Ground", false); 	
			rigidbody2D.AddForce (new Vector2(0,jumpForce));
			// Can the player jump again??
			availableJumps--;
			if (availableJumps < 1 ){    
				canJump = false;
				//Debug.Log(" animasi double jump true bero");
				//anim.SetBool("Doublejump", false);   
			}   
			jump = false;         
		}else{
			//anim.SetBool("Ground", grounded);  
		}
	}     

	void OnCollisionEnter2D(Collision2D coll) { 
		if(coll.gameObject.tag=="groundradius"){     
			cekplayer = false;          
			//collider2D.sharedMaterial.bounciness = 1;
			rigidbody2D.velocity = new Vector3(-10f,0f,0f);    
		}     
	} 
	
}
