using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour {

    private float speedRight = -50.0f;//a speed modifier
    private float speedLeft = 50.0f;//a speed modifier
    public GameObject brain;
    private Vector3 brainPosition;

    void Start()
    {

        brain = GameObject.Find("brain");
        brainPosition = brain.transform.position;
        //transform.LookAt(brain.transform.position);    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, speedLeft * Time.deltaTime,0);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, speedRight * Time.deltaTime,0);
    }
}
