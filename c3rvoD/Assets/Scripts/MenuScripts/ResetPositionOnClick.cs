using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionOnClick : MonoBehaviour
{
    // Reset Brain position
    public void ResetPosition()
    {
        float smooth = 5.0f;
        GameObject brain = GameObject.Find("brain");
        Quaternion target = Quaternion.Euler(-90, 0, 0);

        brain.transform.position = new Vector3(0, 0, 0); //reset position
        brain.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth); // reset rotation
    }
}
