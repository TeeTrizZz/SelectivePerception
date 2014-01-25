using UnityEngine;
using System.Collections;

public class UVElements : MonoBehaviour {

	GameObject character;
	GameObject text;
	public Component[] textMesh;
	static public bool abilityButtonPressed;
	
	void Start () {
		character = this.transform.gameObject;
		//Get the Parent Object of all the UV-Text-Elements
		text = GameObject.Find("UVVisionElements");
	}
	void update()
	{
		abilityButtonPressed = GUIScene.toggleState;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			UVView();
		}
		else{
			disableUVView();
		}
	}

	void UVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
		textMesh = text.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer texMe in textMesh) {
			texMe.enabled = true;
		}
	}
	void disableUVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
		textMesh = text.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer texMe in textMesh) {
			texMe.enabled = false;
		}
	}
}
