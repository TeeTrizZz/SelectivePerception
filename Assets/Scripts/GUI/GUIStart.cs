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

	public Texture2D ggjLogo;
	public Texture2D hfuLogo;

	//the ratio
	public float aspectX;
	public float aspectY;
	//sets a value how much screen should be covered (in percent, e.g.: 90% is 0.9)
	public float coverX;
	public float coverY;

	//for the different menues
	bool showButtons = true;
	bool showCredits = false;
	bool showOptions = false;

	//for the resolution
	public int toolbarInt = 0;
	public string[] toolbarStrings = new string[]{"800x600", "1920x1080"};

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

		Debug.Log (pxDesiredX);


		GUI.BeginGroup (rectResult);
		GUI.DrawTexture (new Rect (0, 0, rectResult.width, rectResult.height), txrBackground, ScaleMode.StretchToFill);
		GUI.BeginGroup (new Rect ((pxDesiredX/2)-((pxDesiredX*0.76f)/2), (pxDesiredY/2)-((pxDesiredY*0.76f)/2), pxDesiredX*0.76f, pxDesiredY*0.76f));

		if (showButtons) {
			if (GUI.Button (new Rect (0, 0, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Start Server")) {
			}
			if (GUI.Button (new Rect (0, (pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Find Host")) {
			}
			if (GUI.Button (new Rect (0, (2 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Options")) {
				showButtons = false;
				showOptions = true;
			}
			if (GUI.Button (new Rect (0, (3 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Credits")) {
				showButtons = false;
				showCredits = true;

			}
			if (GUI.Button (new Rect (0, (4 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Exit")) {
				Application.Quit ();
				//is ignored in editor and webplayer
			}
		}
		if (showCredits) {
			GUI.Label (new Rect(20,20,pxDesiredX * 0.76f, 3*  (pxDesiredY * 0.76f) / 5), "Developed for Global Game Jam 2014 \n\nat Games Lab Hochschule Furtwangen University\n\nTeam:\n\nSascha Englert, Fabian Gaertner, Sarah Haefele, Matthias Kaufmann, \nStefanie Mueller, Benjamin Ruoff", style);
			GUI.DrawTexture (new Rect (20, 240, 100, 100), ggjLogo, ScaleMode.StretchToFill);
			GUI.DrawTexture (new Rect (150, 240, 247, 100), hfuLogo, ScaleMode.StretchToFill);
			if (GUI.Button (new Rect (0, (4 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Back")) {
				showCredits = false;
				showButtons = true;
			}

		}

		if (showOptions) {
			GUI.Label (new Rect(20,20, pxDesiredX * 0.76f, 40), "Set your Screen Resolution:", style);

			GUI.BeginGroup(new Rect (0,60,pxDesiredX * 0.76f, 100));
			if (GUI.Button (new Rect(0,0, (pxDesiredX * 0.76f)/2, 50), "800x600")){
				Screen.SetResolution (800,600,true);
			}
			if (GUI.Button (new Rect((pxDesiredX * 0.76f)/2,0, (pxDesiredX * 0.76f)/2, 50), "1920x1080")){
				Screen.SetResolution (1920,1080,true);
			}
			/*if (GUI.Button (new Rect(0,60, 200, 40), "1920x1080", style)){
				Screen.SetResolution (1920,1080,true);
			}*/

			GUI.EndGroup();



			if (GUI.Button (new Rect (0, (4 * pxDesiredY * 0.76f) / 5, pxDesiredX * 0.76f, (pxDesiredY * 0.76f) / 5), "Back")) {
				showOptions = false;
				showButtons = true;
			}
		}

		GUI.EndGroup ();


		GUI.EndGroup ();


	}
}
