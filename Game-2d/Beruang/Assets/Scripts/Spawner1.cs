using UnityEngine;
using System.Collections;

public class Spawner1 : MonoBehaviour {

	// Use this for initialization
	public GameObject[] obj;
	public float spawMin = 3f;
	public float spawMax = 2f;


	void Start () {
		Spawn();
	}

	//memperbanyak objek   
	public void Spawn(){
		//float rand = Random.Range(0,1000);
		//if random number is greater than 700 make a bomb
		/*if(rand > 700){
			Instantiate(obj [Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
		}*/
		//Instantiate(obj [Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
		Instantiate(obj [0], transform.position, Quaternion.identity);

		//Debug.Log(" nilai random " + rand);
		Debug.Log(" time aktifkan invoke " + Time.deltaTime);
		Invoke("Spawn", 10);    
	}
}
