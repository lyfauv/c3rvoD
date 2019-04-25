#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endif

public class QuitOnClick : MonoBehaviour
{
    // Quit the application
    public void Quit()
    {
#if UNITY_EDITOR
        Application.Quit ();
#endif
    }
}
