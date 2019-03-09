using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour {

    private float speedRight = -50.0f; //a speed modifier
    private float speedLeft = 50.0f; //a speed modifier
    public GameObject brain;


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //turn left
            transform.Rotate(0, speedLeft * Time.deltaTime,0);

        if (Input.GetKey(KeyCode.RightArrow)) //turn right
            transform.Rotate(0, speedRight * Time.deltaTime,0);

        if (Input.GetKey(KeyCode.UpArrow)) // Rotate up
            transform.Rotate(speedLeft * Time.deltaTime,0, 0);

        if (Input.GetKey(KeyCode.DownArrow)) // Rotate down
            transform.Rotate(speedRight * Time.deltaTime, 0, 0);
    }
}
