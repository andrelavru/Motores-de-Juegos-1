using UnityEngine;
using System.Collections;

public class CircularMovement : MonoBehaviour {

	float angle =0.0f;
    public float radio = 4.0f;
    float r = 0;
    float t = 0.25f;
	float dt = 0;
	float SPEED = 0.01f;
	bool salto;
	float deltaSalto=0.016f;
	float saltoTime=0.0f;

	// Use this for initialization
	void Start () {
		salto = true;
        r = radio;
	}
	
	// Update is called once per frame
	void Update () {

		/*-------Con Lerp---------*/
		saltoTime += deltaSalto;
		if (saltoTime >= 0.5f) {
			saltoTime = 0;
			salto = true;
		}

		r -= 0.09f;
		if (r <= radio) {
			r = radio;
		}

		angle = Mathf.Lerp (0, 2 * Mathf.PI, t);
		Vector3 p = new Vector3 (r * Mathf.Cos (angle), r * Mathf.Sin (angle));
		transform.position = p;

		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			dt = SPEED;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			dt = -SPEED;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && salto==true)
		{
			r += 2;
			salto = false;
		}

		if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			dt = 0;
		}

		UpdateT ();

	}

	void UpdateT()
	{
		t += dt;

		if (t > 1)
		{
			t = 0;
		}

		if (t < 0)
		{
			t = 1;
		}
	}


}
