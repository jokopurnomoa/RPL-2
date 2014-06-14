using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}   
	void OnTriggerEnter2D(Collider2D other){
		//if the object that triggered the event is tagged player
		if(other.tag == "Players"){
			Debug.Log(" player break ");
			//Debug.Break();
			//return;
			Application.LoadLevel(1);    
		}
		if(other.gameObject.transform.parent){
			Debug.Log(" other.gameObject.transform.parent ");
			Destroy(other.gameObject.transform.parent.gameObject);
		}else{
			Destroy(other.gameObject);
			Debug.Log(" other.gameObject ");
		}
	}
}
