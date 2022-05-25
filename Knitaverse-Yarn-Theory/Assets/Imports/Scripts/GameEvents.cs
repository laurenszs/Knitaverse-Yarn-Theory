using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void UpdateSquareNumber(int number);
    public static event UpdateSquareNumber OnUpdateSquareNumber;

    public static void UpdateSquareNumberMethod(int number)
    {
        // whenever this function is called, execute all other functions linked to OnUpdateSquareNumber
        if (OnUpdateSquareNumber != null)
        {
            OnUpdateSquareNumber(number);
        }
    }

    public delegate void SquareSelected(int squareIndex);
    public static event SquareSelected OnSquareSelected;

    public static void SquareSelectedMethod(int squareIndex)
    {
        if (OnSquareSelected != null)
        {
            OnSquareSelected(squareIndex);

        }
    }

    public delegate void WrongNumber();
    public static event WrongNumber OnWrongNumber;

    public static void OnWrongNumberMethod()
    {
        if (OnWrongNumber != null)
        {
            OnWrongNumber();
        }
    }

    public delegate void BoardCompleted();
    public static event BoardCompleted OnBoardCompleted;

    public static void OnBoardCompletedMethod()
    {
        if(OnBoardCompleted != null)
        {
            OnBoardCompleted();
        }
    }
}
