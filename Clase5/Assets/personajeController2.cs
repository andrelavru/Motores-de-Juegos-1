using UnityEngine;
using System.Collections;

public class personajeController2 : MonoBehaviour
{
	float SPEEDX = 2;
	float SPEEDY = 4;

	bool isJumping = false;
	float prevVelocity = 0;

	Rigidbody2D body;
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		// Controla los inputs

		if (Input.GetKey(KeyCode.A))
		{
			transform.localScale = new Vector3 (-1, 1, 1);
			body.velocity = new Vector2 (-SPEEDX, body.velocity.y);
			animator.SetBool ("IsWalking", true);

		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.localScale = new Vector3 (1,1,1);
			body.velocity = new Vector2 (SPEEDX, body.velocity.y);
			animator.SetBool ("IsWalking", true);
		}

		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			animator.SetBool ("IsWalking", false);
			body.velocity = new Vector2 (0, body.velocity.y);

		}

		if (Input.GetKey(KeyCode.W)&&!isJumping)
		{
			isJumping = true;
			animator.SetBool ("IsJumping", true);
			body.AddForce (new Vector2(0, SPEEDY), ForceMode2D.Impulse);
		}



	}
}