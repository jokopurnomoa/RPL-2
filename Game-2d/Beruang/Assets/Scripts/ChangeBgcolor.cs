using UnityEngine;
using System.Collections;

public class ChangeBgcolor : MonoBehaviour {

	// Use this for initialization
	public Color color1 = Color.red;
	public Color color2 = Color.blue;
	public float duration = 3.0F;
/*	private Color bgcolor;
	private float t = 0f; */
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float t = Mathf.PingPong(Time.time, duration) / duration;
		camera.backgroundColor = Color.Lerp(color1, color2, t);
	}

	/*void bgColorShifter(){
		while(true){
		
			bgcolor = Color(Random.value, Random.value, Random.value, 1.0);

		}
	}*/

	void Example() {
		camera.clearFlags = CameraClearFlags.SolidColor;
	}
}
