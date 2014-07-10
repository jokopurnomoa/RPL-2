using UnityEngine;
using System.Collections;

public class ControllerPlayer : MonoBehaviour {
	//This will be our maximum speed as we will always be multiplying by 1
	public float maxSpeed = 2f;
	//a boolean value to represent whether we are facing left or not

	//a value to represent our Animator
	Animator anim;
	//to check ground and to have a jumpforce we can change in the editor
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	
	// Use this for initialization
	void Start () {
		//set anim to our animator
		anim = GetComponent <Animator>();
	}

	void FixedUpdate () {
		//set our vSpeed
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		float vertikal = rigidbody2D.velocity.y;
		Debug.Log(" nilai posisi vertikal " +vertikal);
		//set our grounded bool
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//set ground in our Animator to match grounded
		anim.SetBool ("Ground", grounded);
		//move our Players rigidbody

		//set our speed
	}
	
	void Update(){
		//if we are on the ground and the space bar was pressed, change our ground state and add an upward force
		if(grounded && Input.GetKeyDown (KeyCode.Space)){
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce (new Vector2(0,1000f));
			Debug.Log(" jump ");
		}  
	}

}