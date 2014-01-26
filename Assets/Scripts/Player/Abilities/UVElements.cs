using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UVElements : MonoBehaviour {

	private GameObject character;
    private List<MeshRenderer> text;

	private bool abilityButtonPressed;
	private float startTime;
	private float durationAbility = 4f;
	private bool count;
	
	void Start () {
		character = this.transform.gameObject;
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

    public void SetText(List<MeshRenderer> temp)
    {
		text = temp;
	}

	void UVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
		foreach (var gO in text)
			gO.enabled = true;

		startTime = Time.time;
		count = true;
	}
	void disableUVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
        foreach (var gO in text)
            gO.enabled = false;

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
