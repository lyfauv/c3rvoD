using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {

    // Update is called once per frame
    void Update () {

        //Zoom with Scroll wheel
        if(Input.GetAxis("Mouse ScrollWheel") > 0) //zoom in
        {
            GetComponent<Camera>().fieldOfView--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) //zoom out
        {
            GetComponent<Camera>().fieldOfView++;
        }

        //Zoom with arrows
        if (Input.GetKey(KeyCode.Z))
            GetComponent<Camera>().fieldOfView--;

        if (Input.GetKey(KeyCode.S))
            GetComponent<Camera>().fieldOfView++;
    }
}
