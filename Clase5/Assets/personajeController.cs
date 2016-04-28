using UnityEngine;
using System.Collections;

public class personajeController : MonoBehaviour
{
	float tWalk = 0;
	float dtWalk = 0;

	float tJump = 0;
	float dtJump = 0;
	float h = 0;
	bool isJumping = false;

	float SPEEDX = 0.01f;
	float FRICTION = 0.9f;

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		// Controla los inputs

		if (Input.GetKey(KeyCode.A))
		{
			dtWalk = -SPEEDX;
			transform.localScale = new Vector3 (-1, 1, 1);
			animator.SetBool ("IsWalking", true);
		}

		if (Input.GetKey(KeyCode.D))
		{
			dtWalk = SPEEDX;
			transform.localScale = new Vector3 (1,1,1);
			animator.SetBool ("IsWalking", true);
		}

		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			dtWalk *= FRICTION;
			animator.SetBool ("IsWalking", false);

		}

		if (Input.GetKey(KeyCode.W))
		{
			isJumping = true;
			animator.SetBool ("IsJumping", true);
		}

		// Controla lerp WALK
		float px = Mathf.Lerp(-12f, 12f, tWalk);
		Vector3 pWalk = new Vector3(px, 0, 0);

		transform.position = pWalk;

		tWalk += dtWalk*Time.deltaTime*100;
		if (tWalk < 0) tWalk = 0;
		if (tWalk > 1) tWalk = 1;

		// Controla lerp JUMP
		if (isJumping)
		{
			h = 3 * Mathf.Lerp(0, 1, 4 * tJump - 4 * tJump * tJump);
			Vector3 pJump = new Vector3(0, h, 0);
			transform.position += pJump;

			tJump += 0.03f*Time.deltaTime*100;
			if (tJump >= 1)
			{
				tJump = 0;
				isJumping = false;
				animator.SetBool ("IsJumping", false);
			}
		}

	}
}