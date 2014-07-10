using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	private int ButtonWidth = 75;
	private int ButtonHeight = 20;
	private int GroupWidth = 75;
	private int GroupHeight = 80;
	bool paused = false;
	public GUIStyle backgroundstyle;
	void Start () {
		Screen.lockCursor = true;   
		Time.timeScale =1;
	}

	void OnGUI()
	{
		if(paused)
		{
			GUI.BeginGroup(new Rect(((Screen.width/2)-(ButtonWidth/2)),((Screen.height/2)-(ButtonHeight/2)),GroupWidth,GroupHeight),backgroundstyle);          
		    
			if(GUI.Button(new Rect(0,0,ButtonWidth,ButtonHeight),"Main Menu")){  
				Application.LoadLevel(0);
			}
			if(GUI.Button(new Rect(0,25,ButtonWidth,ButtonHeight),"Restart")){  
				Application.LoadLevel(1);
			}
			if(GUI.Button(new Rect(0,50,ButtonWidth,ButtonHeight),"Quit")){  
				Application.Quit();
			}   
			GUI.EndGroup();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			paused = toogglePause();
		}
	}

	bool toogglePause()
	{
		if(Time.timeScale == 0)
		{
			Screen.lockCursor = true;
			Time.timeScale = 1;
			return false;   
		}else{
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return true;
		}
	}
}
