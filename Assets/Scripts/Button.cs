using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private void OnMouseOver()
    {
        Debug.Log("mouse over");
    }

    private void OnMouseExit()
    {
        Debug.Log("mouse exit");
    }
}
