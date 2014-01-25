using UnityEngine;
using System.Collections;

public class WallhackSpark : MonoBehaviour {

	private GameObject gameObjHit;
	private Renderer wallMesh;
	private int counterOnce;
	Color temp;
	GameObject tempColor;
	float startTime;
	float durationAbility = 4f;
	static public bool abilityButtonPressed;
	bool count;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		abilityButtonPressed = GUIScene.doAbility;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			WallhackGo();
		}
		if(count == true)
		{
			counter();
		}
	}
	//Start wallhack
	void WallhackGo()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
		{
			if(counterOnce == 0)
			{
			gameObjHit = hit.transform.gameObject;
			Debug.Log(gameObjHit.name);
			if(gameObjHit.name == "Wall(Clone)")
			{
				Debug.Log("Change Alpha");
				tempColor = gameObjHit;
				temp = tempColor.renderer.material.color;
				temp.a = 0.2f;
				tempColor.renderer.material.color = temp;
				counterOnce++;
			}
			startTime = Time.time;
			count = true;
			}
		}
	}
	//Stop wallhack
	void WallhackStop()
	{
		Debug.Log(wallMesh);
		temp.a = 1f;
		tempColor.renderer.material.color = temp;
		count = false;
		counterOnce = 0;
	}
	void counter()
	{
		int dif = Mathf.RoundToInt(durationAbility - (Time.time - startTime));
		////Debug.Log(dif);
		if (dif < 0) {
			WallhackStop();
		}
	}
}
