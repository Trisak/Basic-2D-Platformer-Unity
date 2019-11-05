using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFlipChildCamera : MonoBehaviour {

	bool noFlip = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject Player = GameObject.Find("Player");
		PlayerMove PMS = Player.GetComponent<PlayerMove>();
		if (PMS.dirX > 0 && !noFlip)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (PMS.dirX < 0 && noFlip)
			{
				// ... flip the player.
				Flip();
			}
		
	}
	
	void Flip()
	{
		// Switch the way the player is labelled as facing.
		noFlip = !noFlip;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		Vector3 thePos = transform.localPosition;
		thePos.x *= -1;
		transform.localPosition = thePos;
	}
}
