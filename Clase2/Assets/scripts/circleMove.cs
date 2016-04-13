using UnityEngine;
using System.Collections;

public class circleMove : MonoBehaviour {

	// Use this for initialization
	float angle = 0;
	float r = 20.0f;
	float t = 0.25f;
	float dt = 0;
	float SPEED = 0.01f;

	void Start () {		
	}

	// Update is called once per frame
	void Update () 
	{
		angle = Mathf.Lerp (0, 2*Mathf.PI,t);

		Vector3 p = new Vector3 (r * Mathf.Cos (angle), r * Mathf.Sin (angle));
		transform.position = p;

		if(Input.GetKey(KeyCode.LeftArrow)){
			dt = SPEED;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			dt = -SPEED;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			dt = 0;
		}
		updateT ();
	}

	void updateT()
	{
		t += dt;

		if (t > 1) {
			t = 0;
		}

		if (t < 0) {
			t = 1;
		}
	}
}

