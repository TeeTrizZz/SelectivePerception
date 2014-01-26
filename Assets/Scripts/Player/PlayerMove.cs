using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private float speed = 1f;
    private bool continueJump = false;
    private float speedJumpStart = 0.03f;
	private float jumpHeight;
	private float gravity = 0.0015f;
    private float startPosYAxis;

    float _rotY;
    float _rotX;
    float delta = 0f;

    public bool BlockMe;
    public GameObject SetMeSomeWhere;

	// Use this for initialization
	void Start () {
        BlockMe = false;
        SetMeSomeWhere = null;

		jumpHeight = speedJumpStart;
		startPosYAxis = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void move()
	{
        if (networkView.isMine && SetMeSomeWhere == null)
        {
            // rotate
            _rotY += Input.GetAxis("Mouse X") * 2.0f;
            this.transform.eulerAngles = new Vector3(0, _rotY, 0);

            if (!BlockMe)
            {
                //Walk forward
                if (Input.GetAxis("Vertical") != 0)
                {
                    transform.Translate(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed, Space.World);
                    transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
                }

                //Rotate
                if (Input.GetAxis("Horizontal") != 0)
                    transform.Translate(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed, Space.World);

                //Jump
                if (Input.GetAxis("Jump") != 0 || continueJump == true)
                {
                    continueJump = true;
                    jump(startPosYAxis);
                }
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wire")
            BlockMe = true;

        if (other.tag == "Trap")
            SetMeSomeWhere = other.gameObject;
    }

    public void SetYouBack()
    {
        SetMeSomeWhere = null;
        transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
    }

    public void YouAreFree()
    {
        BlockMe = false;
    }
}
