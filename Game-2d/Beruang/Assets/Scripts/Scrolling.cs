using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class Scrolling : MonoBehaviour {

	// Use this for initialization
	//scolling speed
	public Vector2 speed = new Vector2(2,2);
	//moving direction
	public Vector2 direction = new Vector2(-1, 0);
	//is linked to camera
	public bool isLinkedTocamera = false;
	//background is infinity
	public bool isLooping = false;
	// list of children with render
	private List<Transform> backgroundPart;

	void Start ()
	{
		//for infinite backgorund only
		if(isLooping){
			backgroundPart = new List<Transform>();

			for(int i = 0; i < transform.childCount; i++){
				Transform child = transform.GetChild(i);
				//Add onlythe visible children
				if(child.renderer != null){
					backgroundPart.Add(child);
				}
			}
			// Sort by position.
			// Note: Get the children from left to right.
			// We would need to add a few conditions to handle
			// all the possible scrolling directions.
			backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();

		}
	
	}    
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
		movement *= Time.deltaTime;
		transform.Translate(movement);
		// move the camera
		if(isLinkedTocamera){
			Camera.main.transform.Translate(movement);
		}

		// 4 - Loop
		if(isLooping)
		{   
			// Get the first object.
			// The list is ordered from left (x position) to right.
			Transform firstchild = backgroundPart.FirstOrDefault();
			if(firstchild != null)
			{
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				if(firstchild.position.x < Camera.main.transform.position.x)
				{
					// If the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if(firstchild.renderer.IsvisibleFrom(Camera.main) == false)
					{
						// Get the last child position.
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
						// Set the position of the recyled one to be AFTER
						// the last child.
						// Note: Only work for horizontal scrolling currently.
						firstchild.position = new Vector3(lastPosition.x + lastSize.x, firstchild.position.y, firstchild.position.z);
						// Set the recycled child to the last position
						// of the backgroundPart list.
						backgroundPart.Remove(firstchild);
						backgroundPart.Add(firstchild);  
					}
				}
			}     

		}
	}
}
