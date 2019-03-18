using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorChange : MonoBehaviour
{
    public Color actualColor = Color.white;
    private Renderer rend;

    public void OnMouseDown()
    {
        Debug.Log("Click !");
        if (rend.material.color == Color.white || rend.material.color == Color.black)
        {
            rend.material.color = Color.green;
            
        }

        else
            rend.material.color = Color.white;
        actualColor = rend.material.color;
    }

    // Start is called before the first frame update
    void Start () {
        rend = gameObject.GetComponentInChildren<Renderer>(); 
        rend.material.color = Color.white;
	}
}
