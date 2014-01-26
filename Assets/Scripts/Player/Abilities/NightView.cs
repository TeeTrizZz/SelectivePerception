using UnityEngine;
using System.Collections;

public class NightView : MonoBehaviour {

	private bool abilityButtonPressed;
	private bool timerAbility;
	private Transform prefabSpotlight;
	private GameObject character;
	private Transform Temp;
	private float startTime;
	private float durationAbility = 4f;

	void Start () {
		character = GameObject.FindWithTag("Player");
	}

	void Update () {
		abilityButtonPressed = GUIScene.doAbility;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			activateNightView();
		}
		if(Temp != null)
		{
			Temp.position = character.transform.position;
			Temp.rotation = character.transform.rotation;
			counter();
		}
	}
	void activateNightView()
	{
		//Instantiate Spotlight 
		if(Temp == null)
		{
			Temp = Instantiate(prefabSpotlight, character.transform.position, Quaternion.identity) as Transform;
			startTime = Time.time;
			//abilityButtonPressed = false;
		}
	}
	void deactivateNightView()
	{
		//Destroy Spotlight
		Destroy(Temp.gameObject);
	}
	void counter()
	{
		int dif = Mathf.RoundToInt(durationAbility - (Time.time - startTime));
		Debug.Log(dif);
		if (dif < 0) {
		deactivateNightView();
		}
	}
}
