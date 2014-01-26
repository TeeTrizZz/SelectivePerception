using UnityEngine;
using System.Collections;

public class TriggerGoalEnd : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		GameData.menuType = 6;
		Application.LoadLevel("Win");
	}
}
