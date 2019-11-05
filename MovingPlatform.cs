﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	float dirx, moveSpeed = 1f;
	bool moveRight = true;

	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 2f)
			moveRight = false;
		if(transform.position.x < 0)
			moveRight = true;
		
		if(moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}
}
