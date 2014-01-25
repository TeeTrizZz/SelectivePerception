using UnityEngine;
using System.Collections;

public class GUIStart : MonoBehaviour {

	//scene to load
	private string levelName = "scene";
	//start scene texture
	public Texture startScreen;
	//intro music
	//public AudioClip intro;
	//GUI Style
	public GUIStyle style;

	// Use this for initialization
	void Start () {
		style.normal.textColor = Color.white;

		style.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnGUI() {
		float width = Screen.width / 1.1f;
		float height = Screen.height / 1.3f;

		float dWidth = (Screen.width - width) / 2;
		float dHeight = (Screen.height - height) / 2;

		
	
		//GUI.DrawTexture (new Rect (30, 0, horizRatio, vertRatio), startScreen, ScaleMode.StretchToFill, true);

		GUI.BeginGroup (new Rect (dWidth, dHeight, Screen.width, Screen.height));



		GUI.DrawTexture (new Rect (0, 0, width, height), startScreen, ScaleMode.ScaleToFit, true);
		                
		if (GUI.Button (new Rect(Screen.width/2 -150 ,Screen.height/2 - 30,150,30), "Start")) {
			Application.LoadLevel (levelName);
		}

		GUI.EndGroup ();
	}
}
