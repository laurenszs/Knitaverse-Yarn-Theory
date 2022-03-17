using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GridSquare : Button, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    private int Number = 0;
    private int correctNumber = 0;

    private bool isSelected = false;
    private int squareIndex = -1;

    private bool hasDefaultValue = false;

    public void SetHasDefaultValue(bool hasDeafaultValue_)
    {
        hasDefaultValue = hasDeafaultValue_;
        if (hasDefaultValue)
        {
            var colors = this.colors;
            colors.normalColor = Color.cyan;
            this.colors = colors;
        }
    }
    public bool GetHasDefaultValue() { return hasDefaultValue; }
    public bool IsSelected() { return isSelected; }

    public bool IsCorrectNumberSet() { return Number == correctNumber; }
    public void SetSquareIndex(int index)
    {
        squareIndex = index;
    }

    public void SetCorrectNumber(int number)
    {
        correctNumber = number;
    }

    public void SetCorrectNumber()
    {
        Number = correctNumber;
    }
     void Start()
    {
        isSelected = false;
    }
    public void DisplayNumber()
    {
        if (Number == 0)
        {
            GetComponentInChildren<Text>().text = "";
        }
        if (Number > 0)
        {
            GetComponentInChildren<Text>().text = Number.ToString();
        }
    }
    public void SetNumber(int number)
    {
        Number = number;
        DisplayNumber();


    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = true;
        GameEvents.SquareSelectedMethod(squareIndex);
    }

    public void OnSubmit(BaseEventData eventData)
    {

    }

    private void OnEnable()
    {
        // I Add an event
        GameEvents.OnUpdateSquareNumber += OnSetNumber;
        GameEvents.OnSquareSelected += OnSquareSelected;
    }
    private void OnDisable()
    {
        // I remove the event after its been done to avoid any hassle
        GameEvents.OnUpdateSquareNumber -= OnSetNumber;
        GameEvents.OnSquareSelected -= OnSquareSelected;
    }

    public void OnSetNumber(int number) // this function needs to have the same parameters as the OnUpdateSquareNumber delegate
    {
        if (isSelected && hasDefaultValue == false)
        {
            SetNumber(number);

            if (number != correctNumber)
            {
                /*var colors = this.colors;
                colors.normalColor = Color.red;
                this.colors = colors;*/
                GameEvents.OnWrongNumberMethod();
            }
            else
            {
                /*hasDefaultValue = true;*/
                var colors = this.colors;
                colors.normalColor = Color.white;
                this.colors = colors;

            }
        }
    }

    public void OnSquareSelected(int squareIndex_)
    {
        if (squareIndex != squareIndex_)
        {
            isSelected = false;
        }
    }
}
