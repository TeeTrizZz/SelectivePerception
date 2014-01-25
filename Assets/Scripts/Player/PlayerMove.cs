using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	static public int speed = 5;
	public float rotSpeed = 100f;
	public bool continueJump = false;
	public float speedJumpStart = 0.05f;
	public float jumpHeight;
	public float gravity = 0.001f;
	public float startPosYAxis;

    float _rotY;
    float _rotX;
    float delta = 0f;

	// Use this for initialization
	void Start () {
		jumpHeight = speedJumpStart;
		startPosYAxis = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void move()
	{
        if (networkView.isMine)
        {
            // rotate
            _rotY += Input.GetAxis("Mouse X") * 2.5f;
            _rotX -= Input.GetAxis("Mouse Y") * 2.5f;
            _rotX = Mathf.Clamp(_rotX, -50f, 50f);

            this.transform.eulerAngles = new Vector3(_rotX, _rotY, 0);

            //Walk forward
            if (Input.GetAxis("Vertical") != 0)
            {
                var y = transform.position.y;
                transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed, Space.Self);
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }

            //Rotate
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Translate(-Vector3.left * Input.GetAxis("Horizontal") * Time.deltaTime * speed, Space.Self);
            }

            //Jump
            if (Input.GetAxis("Jump") != 0 || continueJump == true)
            {
                continueJump = true;
                jump(startPosYAxis);
            }
        }
	}

	//Jump function
	void jump(float startPosY)
	{
		continueJump = true;
		jumpHeight = jumpHeight-gravity;
		transform.Translate(Vector3.up*jumpHeight);

		if(transform.position.y <= startPosY && jumpHeight<=0)
		{
			continueJump = false;
			jumpHeight = speedJumpStart;
		}
	}

}
