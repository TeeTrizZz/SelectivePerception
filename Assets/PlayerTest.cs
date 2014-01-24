using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour {
    public float speed = 10f;
 
    void Update()
    {
        if (networkView.isMine)
        {
            InputMovement();
        }
    }

    void OnGUI()
    {
        //if (networkView.isMine)
        //{
            if (GUI.Button(new Rect(10, 10, 50, 50), "Links"))
                rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
        //}
    }
 
    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
            rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.S))
            rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.D))
            rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.A))
            rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
    }
}