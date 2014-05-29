
using UnityEngine;
using System.Collections;

public class C_Player2 : MonoBehaviour {
	
	//arah ke kanan (x positif)
	public Vector2 direction = new Vector2(1,0);
	
	//extends class movescripts
	//public Movescripts getmove;

	public float maxSpeed = 2f;
	public int maxAirJumpCount = 1;
	public float normalJumpForce = 8f;
	public float airJumpForce = 8f;
	public float raycastDistance = 1f;
	public float xSpeed  = 10f;
	private int airJumpCount = 0;
	private float xMove; 
	private bool isGrounded = false; //is the player on the ground?
	
	//bool facingleft = true;
	Animator anim;
	//private Vector2 movement;
	private Vector2 movement;
	//to check ground and to habe a jumpforce we can change in the editor
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	private bool doublejump = true;
	private int numberofjump = 0;
	
	// Use this for initialization
	
	public Vector2 lariotomatis()
	{
		movement = new Vector2(maxSpeed * direction.x, rigidbody2D.velocity.y);
		return movement;	
	}
	
	
	void Start () {
		
		anim = GetComponent<Animator>();	
	}
	
	void Update () {
		
	
		jumpplayer();
	}
	
	void jumpplayer()
	{
		if(Physics.Raycast(transform.position, -Vector3.up, raycastDistance)){
			
			isGrounded = true;
			airJumpCount = maxAirJumpCount;
		}
		else {
			
			isGrounded = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Space)) {
			
			if(isGrounded) {
				JumpNormal();
			}
			else if(airJumpCount > 0) {
				
				airJumpCount -= 1;
				JumpInAir();
			}
		}
		
		xMove = 0;
		xMove = Input.GetAxisRaw("Horizontal") * xSpeed;
		
	}
	

	// Update is called once per frame
	
/*	void OnCollisionEnter(Collision hit)
	{
		grounded =true;  
		doublejump = true;
		Debug.Log(" hai oncolision di aktifkan karena mendapat benturan");
	}*/
	

	void FixedUpdate()
	{
		anim.SetFloat("vSpeed",rigidbody2D.velocity.y);
		//set grounded boolean
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
		//set ground in our animator jika objek jump maka animasi jump == true, jika objek mengenai tanah maka animasi false
		anim.SetBool("Ground",grounded);
		
	
		rigidbody2D.velocity = lariotomatis();
	}
	


	void JumpNormal()
	{
		//rigidbody2D.AddForce(Vector2.up * normalJumforce, ForceMode.Impulse);
		//rigidbody2D.AddForce(new Vector3.up * normalJumpForce, ForceMode.Impulse);
		rigidbody2D.AddForce(new Vector2(0, 500));
	}

	void JumpInAir()
	{
	//	rigidbody2D.AddForce(new Vector3.up * airJumpForce, ForceMode.Impulse);
	}
}
