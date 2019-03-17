using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorChange : MonoBehaviour, IPointerDownHandler
{
    public Color actualColor = Color.white;
    private Renderer rend;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click !");
        if (rend.material.color == Color.white)
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

    // Update is called once per frame
    void Update () {
        //if(Input.GetKey(KeyCode.Mouse0)) //change brain color when user click
        //{
        //    if (rend.material.color == Color.white)
        //    {
        //        rend.material.color = Color.green;
        //    }

        //    else
        //        rend.material.color = Color.white;
        //}
    }
}
