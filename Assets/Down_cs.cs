using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Down_cs : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public bool downPress = false;
    public bool downExit = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        downPress = true;
        downExit = false;
        Debug.Log("Downclick");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downExit = true;
        downPress = false;
        Debug.Log("DownOut");
    }
}
