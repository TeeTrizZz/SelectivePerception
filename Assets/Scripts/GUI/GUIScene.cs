using UnityEngine;
using System.Collections;

public class GUIScene : MonoBehaviour {

	//toggle state of the skill button
	public static bool toggleState = false;

	public static bool doAbility = false;

	float startTime;
	int dif;

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

	void OnGUI() {
			
				if (GUI.Button (new Rect (5 , 5, 105, 105), skill)) {
					if (!toggleState) {
								toggleState = true;
								doAbility = true;
								startTime = Time.time; //save start time after clicking the button
						}
				}
				//show cooldown time
				if (toggleState) {
					
					dif = Mathf.RoundToInt(coolDown - (Time.time - startTime));
					GUI.Label (new Rect (5, 5, 105, 105), dif.ToString(), style);
					if (dif<=coolDown-1) {
						doAbility = false;
					}
					if (dif <0) {
						toggleState = false;
					}

				
				}
		}
}
