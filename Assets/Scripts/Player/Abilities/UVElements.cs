using UnityEngine;
using System.Collections;

public class UVElements : MonoBehaviour {

	GameObject character;
	GameObject text;
	public Component[] textMesh;
	
	void Start () {
		character = this.transform.gameObject;
		//Get the Parent Object of all the UV-Text-Elements
		text = GameObject.Find("UVVisionElements");
		UVView();
	}

	void UVView()
	{
		//All of the "UV"-3D-Texts shall be visible to the UV-Spark
		textMesh = text.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer texMe in textMesh) {
			texMe.enabled = true;
		}
	}
}
