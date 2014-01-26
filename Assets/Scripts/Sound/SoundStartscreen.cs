using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class SoundStartscreen : MonoBehaviour {

	public AudioClip intro;

	// Use this for initialization
	void Start () {
		audio.loop = true;
		AudioSource.PlayClipAtPoint (intro, gameObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
