using UnityEngine;
using System.Collections;

public class TrapDetector : MonoBehaviour {
	static public bool abilityButtonPressed;
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		abilityButtonPressed = GUIScene.toggleState;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			detectTrap();
		}
		else{
			TrapNormal();
		}
	}

	void detectTrap()
	{
		foreach(GameObject TrabObj in GameObject.FindObjectsOfType<GameObject>())
		{
			if(TrabObj.name == "TrapPlane(Clone)")
			{
				Renderer tempRend = TrabObj.GetComponent<Renderer>();
				tempRend.renderer.material.color = Color.red;
			}
		}
	}
	void TrapNormal()
	{
		foreach(GameObject TrabObj in GameObject.FindObjectsOfType<GameObject>())
		{
			if(TrabObj.name == "TrapPlane(Clone)")
			{
				Renderer tempRend = TrabObj.GetComponent<Renderer>();
				tempRend.renderer.material.color = Color.white;
			}
		}
	}
}
