using UnityEngine;
using System.Collections;

public class UVElements : MonoBehaviour {

	GameObject character;
	GameObject[] text;
	public MeshRenderer textMesh;
	static public bool abilityButtonPressed;
	float startTime;
	float durationAbility = 4f;
	bool count;
	
	void Start () {
		character = this.transform.gameObject;
		//Get the Parent Object of all the UV-Text-Elements
		text = GameObject.FindGameObjectsWithTag("UV-Text");
	}
	void Update()
	{
		abilityButtonPressed = GUIScene.doAbility;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			UVView();
		}
		if(count == true)
		{
			counter();
		}
	}

	void UVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
		foreach (GameObject gO in text) {
			textMesh = gO.GetComponent<MeshRenderer>();
			textMesh.enabled = true;
		}
		startTime = Time.time;
		count = true;
	}
	void disableUVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
		foreach (GameObject gO in text) {
			textMesh = gO.GetComponent<MeshRenderer>();
			textMesh.enabled = false;
		}
		count = false;
	}
	void counter()
	{
		int dif = Mathf.RoundToInt(durationAbility - (Time.time - startTime));
		Debug.Log(dif);
		if (dif < 0) {
			disableUVView();
		}
	}
}
