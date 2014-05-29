using UnityEngine;
using System.Collections;

public class Movescripts : MonoBehaviour {

	public Vector2 speed = new Vector2(5,5);
	//arah
	public Vector2 direction = new Vector2(1,0);

	private Vector2 movement;
	//private Vector3 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

   public Vector2 lariotomatis()
	{
		//movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
		//Debug.Log(string.Format(" nilai speed.x {0}",speed.x));
		movement = new Vector2(speed.x * direction.x, rigidbody2D.velocity.y);
		Debug.Log("nilai speed x = " +speed.x);
		Debug.Log("nilai speed y = " +speed.y);
		Debug.Log("nilai direction x = " +direction.x);
		Debug.Log("nilai direction y = " +direction.y);  
		Debug.Log("nilai movement  = " +movement);  

		return movement;

	}

	void Update () {
		/*movement = new Vector2(
			speed.x * direction.x, speed.y * direction.y);*/
		lariotomatis();
		Debug.Log("lari otomatis  = " +lariotomatis());  
	}


	void FixedUpdate()
	{
		//rigidbody2D.velocity = movement;
		rigidbody2D.velocity = lariotomatis();
	}
}
