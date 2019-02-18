using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour {

    public float speedLeft = 20.0f;//a speed modifier
    public float speedRight = -20.0f;//a speed modifier

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0,0, speedRight * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            //makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
            transform.Rotate(0, 0, speedLeft * Time.deltaTime);
    }
}
