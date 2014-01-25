using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	Transform cam;
	Transform camMain;
	GameObject Char;

	float roty;
	float rotx;
	float delta = 0f;

	// Use this for initialization
	void Start () {
		camMain = transform.FindChild("Main Camera");
		cam = this.transform;
		Char = GameObject.FindWithTag("Player");

		cam.LookAt(Char.transform);
		cam.position = Char.transform.position;
		cam.localEulerAngles = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		cam.position = Char.transform.position;
		camMain.LookAt(Char.transform);
		moveCam();
	}

	void moveCam()
	{
		roty += -Input.GetAxis("Mouse X")*2.5f;
		rotx += Input.GetAxis("Mouse Y")*2.5f;
		rotx = Mathf.Clamp(rotx,-50f,80f);

		cam.localRotation = Quaternion.Euler(rotx,roty,0);
	}
}
