using UnityEngine;
using System.Collections;

public class NightView : MonoBehaviour {

	static public bool abilityButtonPressed;
	public Transform prefabSpotlight;
	GameObject character;
	Transform Temp;

	void Start () {
		character = GameObject.FindWithTag("Player");
	}

	void Update () {
		abilityButtonPressed = GUIScene.toggleState;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			activateNightView();
		}
		else{
			deactivateNightView();
		}
		if(Temp != null)
		{
			Temp.position = character.transform.position;
			Temp.rotation = character.transform.rotation;
		}
	}
	void activateNightView()
	{
		//Instantiate Spotlight 
		if(Temp == null)
		{
		Temp = Instantiate(prefabSpotlight, character.transform.position, Quaternion.identity) as Transform;
		}
	}
	void deactivateNightView()
	{
		//Destroy Spotlight
		Destroy(Temp);
	}
}
