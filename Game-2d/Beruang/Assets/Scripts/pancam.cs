﻿using UnityEngine;
using System.Collections;

public class pancam : MonoBehaviour {


	// Use this for initialization
	//float ydir = 0f;
	public GameObject player;

	void Start () {    
	
	}     
	
	// Update is called once per frame
	void Update () {

		if(player)
		{
			if (player.transform.position.x > 17.82573) {

			/*	float randy = 0f;
				randy = Random.Range (0f, 100f);
				if (randy < 5) {
					ydir = ydir + .005f;
				} else if (randy > 5 && randy < 20) {
					ydir = ydir - .005f;
				} else if (randy > 30) {
					ydir = 0f;
				}*/    
				transform.position = new Vector3 (player.transform.position.x + 0.01f  , transform.position.y , -20);
				//transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y + ydir , -20);

			}
		
		}
	
	}

}
