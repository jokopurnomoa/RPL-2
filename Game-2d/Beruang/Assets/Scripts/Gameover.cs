using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	// Use this for initialization
	int score = 0;
	public GUIElement gui;
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
		score = score * 10;
	}    
	void OnGUI(){
		gui.guiText.text = score.ToString();
		//button retry for load scene 0 game
		if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2 +150,100,40)," Retry")){
			Application.LoadLevel(1);
		}
		//button quit
		if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2 + 200, 100,40),"Quit")){
			//Application.Quit();
			Application.LoadLevel(0);
		}   
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
