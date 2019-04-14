using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ColorChange : MonoBehaviour
{
    private Renderer rend;

    //Change object color after clicking
    public void OnMouseDown()
    {
        // GameObject menu = GameObject.Find("Main menu");
        // if ((rend.material.color == Color.white || rend.material.color == Color.black) && !menu.activeSelf)
        if (rend.material.color == Color.white || rend.material.color == Color.black)
        {
            rend.material.color = Color.green;
            
        }

        else
            rend.material.color = Color.white;
    }

    // Start is called before the first frame update
    void Start () {
        rend = gameObject.GetComponentInChildren<Renderer>(); 
        rend.material.color = Color.white;
	}
}
