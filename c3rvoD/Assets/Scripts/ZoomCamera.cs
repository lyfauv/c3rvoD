using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView++;
        }

    }
}
