using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetPositionOnClick : MonoBehaviour
{
    GameObject cameraRotator;
    Quaternion initialRot;

    // Start is called before the first frame update
    void Start()
    {
        cameraRotator = GameObject.Find("CameraRotator");
        initialRot = cameraRotator.transform.rotation;

    }

    // Reset Brain position by resetting the camera rotator
    public void ResetPosition()
    {
        float speed = 5.0f;
        float step = speed * Time.deltaTime;
        Vector3 targetDir = new Vector3(0, 0, 0);

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        cameraRotator.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
