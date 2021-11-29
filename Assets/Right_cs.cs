using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Right_cs : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Start is called before the first frame update
    public bool rightPress = false;
    public bool rightExit = false;
   

    public void OnPointerDown(PointerEventData eventData)
    {
        rightPress = true;
        rightExit = false;
        Debug.Log("rightclick");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rightExit = true;
        rightPress = false;
        Debug.Log("RightOut");
    }
}
