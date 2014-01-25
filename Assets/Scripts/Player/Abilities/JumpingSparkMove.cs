using UnityEngine;
using System.Collections;

public class JumpingSparkMove : MonoBehaviour {
	static float jumpSparkGravity = 0.0006f;
	static public bool continueJumpSpark = false;
	static float jumpSparkSpeed = 0.07f;
	public static float jumpSparkHeight = jumpSparkSpeed;
	static public bool abilityButtonPressed;
	float startPosY;
	void Start()
	{
		startPosY = this.transform.position.y;
		Debug.Log(startPosY);
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
	public void jumpHighSpark(float startPosY, GameObject tempChar)
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
