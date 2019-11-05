using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour {

	Rigidbody2D rb;
	public float dirX, moveSpeed = 2f;
	public Animator animator;
	private bool m_FacingRight = true;
	public bool isGrounded = false;
	public LayerMask groundLayer;
	public bool InitiateDoubleJump = false;
	public bool DoubleJump = false;
	public int itemsCollected;
	public Text scoreText;
	
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		dirX = Input.GetAxisRaw ("Horizontal") * moveSpeed;
		animator.SetFloat("Speed", Mathf.Abs(dirX));
		displayItemsCollected ();
		
		isGrounded = Physics2D.OverlapArea (new Vector2(transform.position.x - 0.05f, transform.position.y - 0.13f),
			new Vector2(transform.position.x + 0.05f, transform.position.y - 0.14f), groundLayer);


		if (Input.GetButtonDown ("Jump") && rb.velocity.y == 0 && DoubleJump == false)
		{
			isGrounded = false;
			InitiateDoubleJump = true;
			rb.AddForce (Vector2.up * 200f);
			animator.SetBool("IsJumping", true);
		}
		
		if (Input.GetButtonUp ("Jump") && InitiateDoubleJump == true)
		{		
			DoubleJump = true;
		}
		
		if (Input.GetButtonDown ("Jump") && DoubleJump == true)
			{
				DoubleJump = false;
				InitiateDoubleJump = false;
				rb.AddForce (Vector2.up * 150f);
				animator.SetBool("IsJumping", true);
			}
		
		if (isGrounded == true)
		{
			DoubleJump = false;
			InitiateDoubleJump = false;
			animator.SetBool("IsJumping", false);
		}
		
		if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
		
	}

	void FixedUpdate ()
	{
		rb.velocity = new Vector2 (dirX, rb.velocity.y);
		if (dirX > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (dirX < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			
	}

	void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name.Equals ("MovingPlatform"))
			this.transform.parent = col.transform;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.name.Equals ("MovingPlatform"))
			this.transform.parent = null;
	}
	
	void OnDrawGizmos (){
		Gizmos.color = new Color (0,1,0,0.5f);
		Gizmos.DrawCube (new Vector2(transform.position.x, transform.position.y - 0.14f), new Vector2(0.2f, 0.01f));
	}
	
	public void restartLevel (){
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}
	
	public void displayItemsCollected ()
	{
		scoreText.text = "You have collected: " + itemsCollected + " Gems";
	}
}
