using UnityEngine;
using System.Collections;

public class SoundEffectHelper : MonoBehaviour {

	// Use this for initialization
	public static SoundEffectHelper Instance;
	public AudioClip playerSound;
	void Start () {
	
	}
	void Awake(){
		if(Instance != null)
		{
			Debug.LogError("Multiple Instance of soundeffect helper");
		}
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakePlayerSound()
	{
		MakeSound(playerSound);
	}

	private void MakeSound(AudioClip sound)
	{
		AudioSource.PlayClipAtPoint(sound,transform.position);
	}
}
