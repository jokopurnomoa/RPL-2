using UnityEngine;
using System.Collections;

public class SoundOnOff : MonoBehaviour {
	
	public Texture buttonON;
	public Texture buttonOFF;
	public AudioSource backsound;
	private GUITexture buttonONOFF;
	public static bool onoff = false;
	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown()
	{
		buttonONOFF = GetComponent<GUITexture>();

		if(buttonONOFF)
		{
			onoff = true;
			//Debug.Log(" press"+ onoff);
		
			if(backsound.isPlaying)
			{
				guiTexture.texture = buttonOFF;
				backsound.Stop();
			}else{
				guiTexture.texture = buttonON;
				backsound.Play();
			}
		}
	}
	void OnMouseExit()
	{
			onoff = false;
		//	Debug.Log(" exit"+ onoff);

	}

}
