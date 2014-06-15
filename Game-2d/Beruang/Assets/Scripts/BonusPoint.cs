using UnityEngine;
using System.Collections;

public class BonusPoint : MonoBehaviour {

	// Use this for initialization

	//make a container for the heads up display
	Camerafollow cam;

	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == "Players"){
			cam = GameObject.Find("Main Camera").GetComponent<Camerafollow>();
			cam.IncreaseScore(10);
			Destroy(this.gameObject);  
		}  
	}
}
