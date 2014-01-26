using UnityEngine;
using System.Collections;

public class JumpingSparkMove : MonoBehaviour {
	private float jumpSparkGravity = 0.001f;
	static public bool continueJumpSpark = false;
	static float jumpSparkSpeed = 0.07f;
	private float jumpSparkHeight = jumpSparkSpeed;
	private bool abilityButtonPressed;
	float startPosY;
	void Start()
	{
		startPosY = this.transform.position.y;
	}
	void Update()
	{
		abilityButtonPressed = GUIScene.doAbility;
		//If Ability-Button is pressed
		if(abilityButtonPressed == true)
		{
			jumpHighSpark(startPosY, this.gameObject);
		}
		if(continueJumpSpark == true)
		{
			jumpHighSpark(startPosY, this.gameObject);
		}
	}
	//special skill: Jump high to achieve an aerial perspective to get an overview over the labyrinth
	void jumpHighSpark(float startPosY, GameObject tempChar)
	{
		continueJumpSpark = true;
		jumpSparkHeight = jumpSparkHeight-jumpSparkGravity;
		tempChar.transform.Translate(Vector3.up*jumpSparkHeight);
		if(tempChar.transform.position.y <= startPosY && jumpSparkHeight<=0)
		{
			continueJumpSpark = false;
			jumpSparkHeight = jumpSparkSpeed;
			//Debug.Log(isjumping);
		}
	}

}
