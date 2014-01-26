using UnityEngine;
using System.Collections;

public class TriggerGoalEnd : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		GameData.menuType = 7;
		Debug.Log (GameData.menuType);
		Application.LoadLevel("Win");
	}
}
