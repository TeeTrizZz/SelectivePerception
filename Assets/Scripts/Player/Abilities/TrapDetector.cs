using UnityEngine;
using System.Collections;

public class TrapDetector : MonoBehaviour {
	static public bool abilityButtonPressed;
	float startTime;
	float durationAbility = 4f;
	bool count;

	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		abilityButtonPressed = GUIScene.doAbility;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			detectTrap();
		}
		if(count == true)
		{
			counter();
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
			if(TrabObj.name == "stolperfalle(Clone)")
			{
				Renderer tempRend = TrabObj.GetComponent<Renderer>();
				tempRend.renderer.material.color = Color.red;
			}
		}
		startTime = Time.time;
		count = true;
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
			if(TrabObj.name == "stolperfalle(Clone)")
			{
				Renderer tempRend = TrabObj.GetComponent<Renderer>();
				tempRend.renderer.material.color = Color.white;
			}
		}
		count = false;
	}
	void counter()
	{
		int dif = Mathf.RoundToInt(durationAbility - (Time.time - startTime));
		Debug.Log(dif);
		if (dif < 0) {
			TrapNormal();
		}
	}
}
