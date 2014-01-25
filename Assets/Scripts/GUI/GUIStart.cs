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

		Debug.Log (pxDesiredX);


		GUI.BeginGroup (rectResult);
		GUI.DrawTexture (new Rect (0, 0, rectResult.width, rectResult.height), txrBackground, ScaleMode.StretchToFill);
		GUI.BeginGroup (new Rect ((pxDesiredX/2)-((pxDesiredX*0.76f)/2), (pxDesiredY/2)-((pxDesiredY*0.76f)/2), pxDesiredX*0.76f, pxDesiredY*0.76f));
		if (GUI.Button (new Rect(0,0,pxDesiredX*0.76f, (pxDesiredY*0.76f)/5), "Start Server")) {
		}
		if (GUI.Button (new Rect(0,(pxDesiredY*0.76f)/5,pxDesiredX*0.76f, (pxDesiredY*0.76f)/5), "Find Host")) {
		}
		if (GUI.Button (new Rect(0,(2*pxDesiredY*0.76f)/5,pxDesiredX*0.76f, (pxDesiredY*0.76f)/5), "Options")) {
		}
		if (GUI.Button (new Rect(0,(3*pxDesiredY*0.76f)/5,pxDesiredX*0.76f, (pxDesiredY*0.76f)/5), "Credits")) {
		}
		if (GUI.Button (new Rect(0,(4*pxDesiredY*0.76f)/5,pxDesiredX*0.76f, (pxDesiredY*0.76f)/5), "Exit")) {
		}
		GUI.EndGroup ();


		GUI.EndGroup ();


	}
}
