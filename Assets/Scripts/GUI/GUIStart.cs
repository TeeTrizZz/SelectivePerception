using UnityEngine;
using System.Collections;

public class GUIStart : MonoBehaviour {

	//scene to load
	private string levelName = "scene";
	//start scene texture
	public Texture startScreen;
	//intro music
	public AudioClip intro;
	//GUI Style
	private GUIStyle style;

	// Use this for initialization
	void Start () {
		style.normal.textColor = Color.white;
		style.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () {
		GUI.DrawTexture ( new Rect (280, 30, 400, 540), startScreen, ScaleMode.ScaleToFit, true);

	}
}
