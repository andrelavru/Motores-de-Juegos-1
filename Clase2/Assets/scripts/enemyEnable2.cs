using UnityEngine;
using System.Collections;

public class enemyEnable2 : MonoBehaviour {

    // Use this for initialization
    private Vector3 initPoint = new Vector3(0.0f, -10.0f, 0.0f);
    private Vector3 endPoint = new Vector3(0.0f, 10.0f, 0.0f);
    private float t = 0.0f;
	private float duration = 2.0f;
    public float dt;
	void Start () {	
		dt = 1 / (duration * 60.0f);
	}

	// Update is called once per frame
	void Update () {
        //Ida
		transform.position = Vector3.Lerp(initPoint, endPoint, f(t));
       t += dt;                

        if (t > 1)
        {
            t = 0;
            
        }
    }

	float f(float t){
		return Mathf.Sin(t*3.14f);
	}
}
