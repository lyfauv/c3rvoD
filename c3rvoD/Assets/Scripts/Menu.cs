using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Main Menu");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            menu.SetActive(true);
        }

        if (Input.GetKey(KeyCode.F))
        {
            menu.SetActive(false);
        }
    }
}
