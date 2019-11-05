using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWin : MonoBehaviour {
	

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
        GameObject winText = GameObject.Find("Text");
		winText.GetComponent<Text>().enabled = true;
		}
    }
}
