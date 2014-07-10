using UnityEngine;
using System.Collections;

public class GroundSpawn : MonoBehaviour {

	public GameObject[] obj;
	private float lastx = 0f;
	private float timelimit = 30.0f;  
	private float spasi = 0f;
	
	void Start() {
		if(tag == "GroundStart"){
			Instantiate(obj [Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity); 
		}  
	}    
	
	void Update(){
		
		if(( Time.timeSinceLevelLoad >= timelimit) && Time.timeSinceLevelLoad <= 330)
		{
			timelimit += 30.0f;   
			spasi += 4f;       
		}   
		if(transform.position.x > (lastx + 50f + spasi) && (tag !="GroundStart")){
			//Instantiate(prefab, transform.position, Quaternion.identity);
			Instantiate(obj [Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity); 
			lastx = transform.position.x;  	 
		} 
	}

}
