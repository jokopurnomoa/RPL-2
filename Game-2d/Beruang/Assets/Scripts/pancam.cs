using UnityEngine;
using System.Collections;

public class pancam : MonoBehaviour {


	// Use this for initialization
	float ydir = 0f;
	bool transf = false;
	public GameObject player;
	private float addYcamera = 0f;

	void Start () {    
	
	}     
	
	// Update is called once per frame
	void Update () {

		if(player)
		{
			if (player.transform.position.x > -10.20648) {
				
				
				float randy = 0f;
				randy = Random.Range (0f, 100f);
				if (randy < 5) {
					ydir = ydir + .005f;
				} else if (randy > 5 && randy < 20) {
					ydir = ydir - .005f;
				} else if (randy > 30) {
					ydir = 0f;
				}
				transform.position = new Vector3 (player.transform.position.x + 0.01f, transform.position.y , -20);
				//transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y + ydir , -20);

			}
			/*if(player.transform.position.y > 5){
				transf = true;
				addYcamera = cam + 0.01f;
				Debug.Log(" nilai addYcamera > 7 " + addYcamera);
			}else if(player.transform.position.y < 7){
				addYcamera = 7.528365f;
				Debug.Log(" nilai addYcamera < 7 " + addYcamera);
			}*/
			 // transform.position = new Vector3 (player.transform.position.x, transform.position.y + ydir  , -20);
			//transform.position = new Vector3 (player.transform.position.x, addcam()  , -20);
		}
	
	}

	/*private float addcam()
	{
		float cam =0f; 
		if(player.transform.position.y > camera.transform.position.y){

			addYcamera =  player.transform.position.y + 0.01f ;
		}else{
			//addYcamera = 7.528365f;
			//addYcamera = camera.transform.position.y;
		}
		return addYcamera;
		Debug.Log(" nilai addYcamera  " + addYcamera);

	}*/


}
