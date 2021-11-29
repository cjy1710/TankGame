using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class up_cs : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public bool upPress = false;
    public bool upExit = false;
    /*
    void Start()
    {
        Button btn_up = this.GetComponent<Button>();
        EventTrigger _trigger = btn_up.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry enUpEnter = new EventTrigger.Entry();
        EventTrigger.Entry enUpExit = new EventTrigger.Entry();

        // 鼠标进入事件 
        enUpEnter.eventID = EventTriggerType.PointerEnter;
        // 鼠标滑出事件 
        enUpExit.eventID = EventTriggerType.PointerExit;

        enUpEnter.callback = new EventTrigger.TriggerEvent();
        enUpEnter.callback.AddListener(OnMouseEnterUp);
        _trigger.triggers.Add(enUpEnter);


        enUpExit.callback = new EventTrigger.TriggerEvent();
        enUpExit.callback.AddListener(OnMouseExitUp);
        _trigger.triggers.Add(enUpExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnterUp(BaseEventData pointData)
    {
        upPress = true;
        Debug.Log("upclick");
    }
    private void OnMouseExitUp(BaseEventData pointData)
    {
        upExit = true;
        upPress = false;
        Debug.Log("upOut");
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        upPress = true;
        upExit = false;
        Debug.Log("upclick");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        upExit = true;
        upPress = false;
        Debug.Log("upOut");
    }


}
