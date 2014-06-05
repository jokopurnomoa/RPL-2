using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(PlayerPhysics))]
public class C_player : MonoBehaviour {
	
	//arah ke kanan (x positif)
	public Vector2 direction = new Vector2(1,0);

	public float maxSpeed = 2f;
	
	bool facingleft = true;
	Animator anim;
	private Vector2 movement;
	//to check ground and to habe a jumpforce we can change in the editor
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	
	public LayerMask whatIsGround;    
	public float jumpForce = 700f;
	private float time = 2f;
	//private PlayerPhysics PlayerPhysics;
    
	//private bool doublejump = true;
	
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
		
   //  Jumpplayer();
	}
	
		void Jumpplayer()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{

			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(20, jumpForce));
			Debug.Log(" jump true");    
			//Debug.Log(rigidbody2D.AddForce(new Vector2(0, jumpForce)));
			Debug.Log(transform.position.y * maxSpeed);  
		

		 if(!grounded)
			{
				Debug.Log(" nilai ground false ");
			}
			//grounded = false;
		}

	}
	
	void FixedUpdate()
	{
		anim.SetFloat("vSpeed",rigidbody2D.velocity.y);
		//set grounded boolean
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
		//set ground in our animator jika objek jump maka animasi jump == true, jika objek mengenai tanah maka animasi false
		anim.SetBool("Ground",grounded);
		Jumpplayer();

		
		/*	float move = Input.GetAxis("Horizontal");
		Debug.Log("nilai move" +move);
		//movement = new Vector3(move * maxSpeed, rigidbody2D.velocity.y);
		rigidbody2D.velocity = new Vector3(move * maxSpeed, rigidbody2D.velocity.y);
		Debug.Log("nilai rigdbody2d.velocity" +rigidbody2D.velocity);
		//set our spedd*
	
		anim.SetFloat("Speed",Mathf.Abs(move));

		//Debug.Log(move.ToString());
		if(move < 0 && !facingleft)
		{
			Flip();
		}else if(move > 0 && facingleft)
		{
			Flip();
		} 
		movement = new Vector2(speedplayer.x * direction.x, speedplayer.y * direction.y);
		movement = new Vector3(direction.y * maxSpeed, rigidbody2D.velocity.y);
		*/
		
		rigidbody2D.velocity = lariotomatis();

	}
	
	/*void Flip()
	{
		facingleft = !facingleft;
		Vector3 theScale =transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}*/
}
