using UnityEngine;
using System.Collections;

public class BonusPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//make a container for the heads up display
	pancam hd;

	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == "Players"){
			hd = GameObject.Find("Main Camera").GetComponent<pancam>();
			hd.increaseScore(10);
			Destroy(this.gameObject);
		}
	}
}
