using UnityEngine;
using System.Collections;

public class TrapDetector : MonoBehaviour {

	void Start () {

		foreach(GameObject TrabObj in GameObject.FindObjectsOfType<GameObject>())
		{
			if(TrabObj.name == "TrapPlane(Clone)")
			{
				Renderer tempRend = TrabObj.GetComponent<Renderer>();
				tempRend.renderer.material.color = Color.red;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
