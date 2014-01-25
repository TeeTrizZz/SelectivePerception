using UnityEngine;
using System.Collections;

public class JumpingSparkMove : MonoBehaviour {
	static float jumpSparkGravity = 0.006f;
	static float jumpSparkSpeed = 0.50f;
	public static float jumpSparkHeight = jumpSparkSpeed;

public static void jumpHighSpark(float startPosY, Transform tempChar)
	{
		PlayerMove.continueJump = true;
		jumpSparkHeight = jumpSparkHeight-jumpSparkGravity;
		tempChar.Translate(Vector3.up*jumpSparkHeight);
		if(tempChar.position.y <= startPosY && jumpSparkHeight<=0)
		{
			PlayerMove.continueJump = false;
			jumpSparkHeight = jumpSparkSpeed;
			//Debug.Log(isjumping);
		}
	}

}
