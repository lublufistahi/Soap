using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public GameObject UiTextAnatation;
    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        UiTextAnatation.GetComponent<Text>().text = GetComponent<Text>().text;
        
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material.color = Color.white;
        UiTextAnatation.GetComponent<Text>().text = "";
    }
    
}
