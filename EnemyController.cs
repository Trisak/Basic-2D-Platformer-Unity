using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	float dirx, moveSpeed = 1f;
	bool moveRight = true;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > -1f)
		{
			moveRight = false;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		if(transform.position.x < -3f)
		{
			moveRight = true;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		
		if(moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.tag == "Player")
		{
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(gameObject);
		}
    }
	
	void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "Player")
		{
        GameObject Player = GameObject.Find("Player");
		PlayerMove PMS = Player.GetComponent<PlayerMove>();
		PMS.restartLevel();
		}
    }
}
