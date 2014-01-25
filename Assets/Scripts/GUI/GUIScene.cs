using UnityEngine;
using System.Collections;

public class GUIScene : MonoBehaviour {

	//toggle state of the skill button
	public static boolean toggleState = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect(Screen.width/2 -150 ,Screen.height/2 - 30,150,30), "Start")) {
			Application.LoadLevel (levelName);
		}
	}
}
