using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class NumberButton : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{

    public int buttonValue = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

   public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.UpdateSquareNumberMethod(buttonValue);
    }

    public void OnSubmit(BaseEventData eventData)
    {

    }


}
