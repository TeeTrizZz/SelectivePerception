using UnityEngine;
using System.Collections;

public class TriggerGoalEnd : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		Application.LoadLevel("Win");
	}
}
