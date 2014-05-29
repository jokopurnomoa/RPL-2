using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float speed          = 3.0f;
	public float jumpSpeed          = 200.0f;
	public bool grounded            = true;
	public float time           = 4.0f;     
	private bool dblJump = true;
	
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 x = Input.GetAxis("Horizontal")* transform.right * Time.deltaTime *      speed;
		
		if (time <= 2)
		{
			if(Input.GetButtonDown("Jump"))
			{
				Jump();
			}
			
		}
		
		transform.Translate(x);
		
		//Restrict Rotation upon jumping of player object
		transform.rotation = Quaternion.LookRotation(Vector3.forward);
		
		
	}


	void Jump()
	{
		if (grounded == true)
		{
			//rigidbody2D.AddForce(Vector3.up* jumpSpeed);
			rigidbody2D.AddForce(Vector3.up * jumpSpeed);
			
			grounded = false;
		} 
		else if (!grounded && dblJump)
		{
			rigidbody2D.AddForce(Vector3.up * jumpSpeed);
			
			dblJump = false;
		}
		
	}


	void OnCollisionEnter (Collision hit)
	{
		grounded = true;
		dblJump = true;
		// check message upon collition for functionality working of code.
		Debug.Log ("I am colliding with something");
	}
	
}