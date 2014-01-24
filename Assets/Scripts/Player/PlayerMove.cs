using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	static public int speed = 5;
	public float rotSpeed = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void move()
	{
		if (Input.GetAxis ("Vertical") != 0) {
			transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * Time.deltaTime * speed, Space.Self);
		} if (Input.GetAxis ("Horizontal") != 0) {
			transform.Rotate(Vector3.up * Input.GetAxis ("Horizontal")* rotSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetAxis ("Jump") != 0) {
			
		}
	}
}
