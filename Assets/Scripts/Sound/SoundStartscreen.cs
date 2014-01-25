using UnityEngine;
using System.Collections;

public class SoundStartscreen : MonoBehaviour {

	public AudioClip intro;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (intro, gameObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
