using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {

        if(Input.GetAxis("Mouse ScrollWheel") > 0) //zoom in
        {
            GetComponent<Camera>().fieldOfView--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) //zoom out
        {
            GetComponent<Camera>().fieldOfView++;
        }

    }
}
