using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	private GameObject _char;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (_char != null)
        {
            transform.position = _char.transform.position;
            transform.rotation = _char.transform.rotation;
        }
	}

    public void SetTarget(GameObject target)
    {
        _char = target;
        transform.position = _char.transform.position;
    }
}
