using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	Transform cam;
	Transform camMain;
	Transform Char;

	float roty;
	float rotx;
	float delta = 0f;

	// Use this for initialization
	void Start () {
		camMain = transform.FindChild("Main Camera");
		cam = this.transform;
		Char = GameObject.Find("Player").transform;

		cam.LookAt(Char);
		cam.position = Char.position;
		cam.localEulerAngles = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		cam.position = Char.position;
		camMain.LookAt(Char);
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
