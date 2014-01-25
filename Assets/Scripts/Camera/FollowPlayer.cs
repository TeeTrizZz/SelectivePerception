using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	private GameObject _char;

    float _rotY;
    float _rotX;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (_char != null)
        {
            transform.position = _char.transform.position;

            // rotate
            _rotY = _char.transform.rotation.eulerAngles.y;
            _rotX -= Input.GetAxis("Mouse Y") * 2.0f;
            _rotX = Mathf.Clamp(_rotX, -50f, 50f);

            this.transform.eulerAngles = new Vector3(_rotX, _rotY, 0);
        }
	}

    public void SetTarget(GameObject target)
    {
        _char = target;
        transform.position = _char.transform.position;
    }
}
