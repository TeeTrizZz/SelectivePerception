using UnityEngine;
using System.Collections;

public class nightVisionGoggles : MonoBehaviour {

	GameObject character;
	GameObject text;

	// Use this for initialization
	void Start () {
		character = this.transform.gameObject;
		text = GameObject.Find("NightVisionElements");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void checkCharType()
	{
		if(character.name == "NightVisionSpark")
		{
			text.active = true;
		}
		else{
			text.active = false;
		}
	}
}
