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

	public Texture2D txrBackground;
	//the ratio
	public float aspectX;
	public float aspectY;
	//sets a value how much screen should be covered (in percent, e.g.: 90% is 0.9)
	public float coverX;
	public float coverY;

	// Use this for initialization
	void Start () {
		style.normal.textColor = Color.white;

		style.fontSize = 20;
	}

	// Update is called once per frame
	void Update () {


	}

	void OnGUI() {
		//average values
		aspectX = Mathf.Max (1f, aspectX);
		aspectY = Mathf.Max (1f, aspectY);
		coverX = Mathf.Max (0.1f, coverX);
		coverY = Mathf.Max (0.1f, coverY);

		float pxDesiredX = coverX * Screen.width;
		float pxDesiredY = coverY * Screen.height;

		float aspectDesired = 1.0f * aspectX / aspectY;

		if (pxDesiredX / pxDesiredY < aspectDesired) {
			pxDesiredY = pxDesiredX / aspectDesired;
		} else {
			pxDesiredX = pxDesiredY * aspectDesired;
		}

		var pxBorderX = Screen.width - pxDesiredX;
		var pxBorderY = Screen.height - pxDesiredY;

		Rect rectResult = new Rect (pxBorderX / 2, pxBorderY / 2, pxDesiredX, pxDesiredY);

		GUI.BeginGroup (rectResult);
		GUI.DrawTexture (new Rect (0, 0, rectResult.width, rectResult.height), txrBackground, ScaleMode.StretchToFill);
		if (GUI.Button (new Rect (98, 98, rectResult.width, rectResult.height / 5), "Start Server")) {
				}
		GUI.EndGroup ();

		/*
		float width = Screen.width / 1.1f;
		float height = Screen.height / 1.3f;

		float dWidth = (Screen.width - width) / 2;
		float dHeight = (Screen.height - height) / 2;

		
	

		GUI.BeginGroup (new Rect (dWidth, dHeight, Screen.width, Screen.height));



		GUI.DrawTexture (new Rect (0, 0, width, height), startScreen, ScaleMode.ScaleToFit, true);
		                
		if (GUI.Button (new Rect(Screen.width/2 -150 ,Screen.height/2 - 30,150,30), "Start")) {
			Application.LoadLevel (levelName);
		}

		GUI.EndGroup ();
*/
	}
}
