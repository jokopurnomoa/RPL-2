using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (this.gameObject.name == "play") {
			Debug.Log("Button play clicked!");
			Application.LoadLevel("main_scene");
		} else if (this.gameObject.name == "score") {
			
		} else if (this.gameObject.name == "help") {
			
		} else if (this.gameObject.name == "exit") {
			
		}
	}
}
