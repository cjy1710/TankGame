using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shot_touchcs : MonoBehaviour, IPointerDownHandler
{
    public bool b_shot = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        b_shot = true;
        //LeftExit = false;
        Debug.Log("shot trigged");
    }
}
