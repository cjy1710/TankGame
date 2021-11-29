using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Left_cs : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public bool LeftPress = false;
    public bool LeftExit = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        LeftPress = true;
        LeftExit = false;
        Debug.Log("Leftclick");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeftExit = true;
        LeftPress = false;
        Debug.Log("LeftOut");
    }
}
