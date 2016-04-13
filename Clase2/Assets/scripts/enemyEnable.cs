using UnityEngine;
using System.Collections;

public class enemyEnable : MonoBehaviour {

    // Use this for initialization
    //private Vector3 initPoint = new Vector3(-2.0f, 0.0f, 0.0f);
    //private Vector3 endPoint = new Vector3(2.0f, 0.0f, 0.0f);
    public GameObject initObject;
    public GameObject secObject;
    public GameObject terObject;
    public GameObject endObject;
    private float t = 0.0f;
    public float dt = 0.02f;
    private float count = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Ida
        if(count == 0)
        {
            transform.position = Vector3.Lerp(initObject.transform.position, secObject.transform.position, t);
            t += dt;
        }
                
        if (count == 1)
        {
            transform.position = Vector3.Lerp(secObject.transform.position, terObject.transform.position, t);
            t += dt;
        }

        if (count == 2)
        {
            transform.position = Vector3.Lerp(terObject.transform.position, endObject.transform.position, t);
            t += dt;
        }

        //vuelta
        if (count == 3)
        {
            transform.position = Vector3.Lerp(endObject.transform.position, terObject.transform.position, t);
            t += dt;
        }

        if (count == 4)
        {
            transform.position = Vector3.Lerp(terObject.transform.position, secObject.transform.position, t);
            t += dt;
        }

        if (count == 5)
        {
            transform.position = Vector3.Lerp(secObject.transform.position, initObject.transform.position, t);
            t += dt;
        }

        if (t > 1)
        {
            t = 0;
            count += 1;
        }

        if (count > 5)
        {
            count = 0;
        }


    }
}
