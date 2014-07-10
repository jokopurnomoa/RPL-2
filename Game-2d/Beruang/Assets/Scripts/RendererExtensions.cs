using UnityEngine;
using System.Collections;

public static class RendererExtensions  {  
	// Use this for initialization   
	public static bool IsvisibleFrom(this Renderer renderer, Camera camera){
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}
