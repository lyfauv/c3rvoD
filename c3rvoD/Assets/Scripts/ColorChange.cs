using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {
    public Color actualColor = Color.white;
    private Renderer rend;

    void onMouseDown()
    {
        if (rend.material.color == Color.white)
        {
            rend.material.color = Color.green;
        }

        else
            rend.material.color = Color.white;
        actualColor = rend.material.color;
    }

    void Start () {
        rend = gameObject.GetComponentInChildren<Renderer>(); 
        rend.material.color = Color.white;
	}

	void Update () {
	}
}
