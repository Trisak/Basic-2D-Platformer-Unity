﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.tag == "Player")
		{
        GameObject Player = GameObject.Find("Player");
		PlayerMove PMS = Player.GetComponent<PlayerMove>();
		PMS.restartLevel();
		}
    }
}
