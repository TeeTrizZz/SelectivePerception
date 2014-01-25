using UnityEngine;
using System.Collections;

public class GUIScene : MonoBehaviour {

	//toggle state of the skill button
	public static bool toggleState = false;

	float startTime;

	public Texture skill;

	private int coolDown = 30;

	public GUIStyle style;

	// Use this for initialization
	void Start () {
	
		style.normal.textColor = Color.white;
		style.fontSize = 40;
		style.alignment = TextAnchor.MiddleCenter; //aligns the text to middle
	}
	
	// Update is called once per frame
	void Update () {
	
	}

<<<<<<< HEAD
	void OnGUI() {	
		if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 105, 105), skill)) {
				if (!toggleState) {
						toggleState = true;
						startTime = Time.time; //save start time after clicking the button
=======
	void OnGUI() {
			
				//if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 105, 105), skill)) {
				if (GUI.Button (new Rect (5 , 5, 105, 105), skill)) {
						if (!toggleState) {
								toggleState = true;
								startTime = Time.time; //save start time after clicking the button
						}
				}
				//show cooldown time
				if (toggleState) {
					int dif = Mathf.RoundToInt(coolDown - (Time.time - startTime));
					//GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 105, 105), dif.ToString(), style);
					GUI.Label (new Rect (5, 5, 105, 105), dif.ToString(), style);

					if (dif < 0) {
						toggleState = false;
					}
>>>>>>> 0f89abb454daba68e9421f79fbee524b23fe2164
				}
		}

		//show cooldown time
		if (toggleState) {
			int dif = Mathf.RoundToInt(coolDown - (Time.time - startTime));
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 105, 105), dif.ToString(), style);

			if (dif < 0) {
				toggleState = false;
			}
		}
	}
}
