using UnityEngine;
using System.Collections;

public class UVElements : MonoBehaviour {

	GameObject character;
	GameObject text;
	public Component[] textMesh;
	static public bool abilityButtonPressed = true;
	float startTime;
	float durationAbility = 10f;
	bool count;
	
	void Start () {
		character = this.transform.gameObject;
		//Get the Parent Object of all the UV-Text-Elements
		text = GameObject.Find("UVVisionElements");
	}
	void update()
	{
		//abilityButtonPressed = GUIScene.toggleState;
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
		textMesh = text.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer texMe in textMesh) {
			texMe.enabled = true;
		}
		abilityButtonPressed = false;
		count = true;
	}
	void disableUVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
		textMesh = text.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer texMe in textMesh) {
			texMe.enabled = false;
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
