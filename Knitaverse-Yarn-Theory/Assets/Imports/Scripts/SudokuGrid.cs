using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGrid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    
    public GameObject gridImage;

    public float squareOffset = 0.0f;
    public float squareScale = 1.0f;
    public float squareGap = 0.1f;

    public Vector3 startPosition;

    private List<GameObject> gridImages = new List<GameObject>();

    private int selectedGridData = -1;

    private void Start()
    {
        startPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        if(gridImage.GetComponent<GridSquare>() == null)
        {
            Debug.LogError("this go needs to have the GridSquare Script"); // display a logerror whenever the gameobject doesn't contain the GridSquare script
        }
        CreateGrid();
        SetGridNumbers(GameSettings.Instance.GetGameDifficulty());   
    }
    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquarePosition();
    }

    private void SpawnGridSquares()
    {
        int sqaureIndex = 0;
        // creating the rows and collumns
        for (int i = 0; i < rows; i++)
        {
            for (int o = 0; o < columns; o++)
            {
                gridImages.Add(Instantiate(gridImage, this.transform.position, this.transform.rotation)); // instantiate a new image from the list
                gridImages[gridImages.Count - 1].GetComponent<GridSquare>().SetSquareIndex(sqaureIndex);
                gridImages[gridImages.Count - 1].transform.parent = this.transform; // make sure you make the last image that has been instantiated, a child of the object containing the script
                gridImages[gridImages.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);

                sqaureIndex++;
            }
        }
    }
    
    private void SetSquarePosition()
    {
        // offset the position of the 2nd square and so forth.
        var squareRect = gridImages[0].GetComponent<RectTransform>();

        Vector2 offset = new Vector2();
        Vector2 squareGapNumber = new Vector2(0.0f, 0.0f); // indicates how many gaps are already created

        bool rowMoved = false; // indicates whether we switched to the next row or not

        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + squareOffset; // offset on the x axis
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + squareOffset; // offset in the y axis

        int columnNumber = 0;
        int rowNumber = 0;

        foreach (GameObject square in gridImages)
        {
            if(columnNumber +1 > columns) // if the number exceeds the columns
            {

                rowNumber++; // move to the next row
                columnNumber = 0;
                squareGapNumber.x = 0;
                rowMoved = false;
            }
            var xOffset = offset.x * columnNumber + (squareGapNumber.x * squareGap);
            var yOffset = offset.y * rowNumber + (squareGapNumber.y * squareGap);

            if(columnNumber > 0 && columnNumber % 3 == 0)
            {
                squareGapNumber.x++;
                xOffset += squareGap;
            }
            if(rowNumber > 0 && rowNumber % 3 == 0 && rowMoved == false)
            {
                rowMoved = true;
                squareGapNumber.y++;
                yOffset += squareGap;
                    
            }



            square.GetComponent<RectTransform>().anchoredPosition = new Vector3(startPosition.x - xOffset, startPosition.y - yOffset, startPosition.z);
            columnNumber++;
            //Set all the squares in position
        }
            
    }

    private void OnEnable()
    {
        GameEvents.OnUpdateSquareNumber += CheckBoardCompleted;
    }
    private void OnDisable()
    {
        GameEvents.OnUpdateSquareNumber -= CheckBoardCompleted;
    }


    private void SetGridNumbers(string level)
    {
        selectedGridData = Random.Range(0, SudokuData.Instance.sudokuGame[level].Count);
        var data = SudokuData.Instance.sudokuGame[level][selectedGridData];

        SetGridSquareData(data);
    }

    private void SetGridSquareData(SudokuData.SudokuBoardData data)
    {
        for (int i = 0; i < gridImages.Count; i++)
        {
            gridImages[i].GetComponent<GridSquare>().SetNumber(data.unsolvedData[i]);
            gridImages[i].GetComponent<GridSquare>().SetCorrectNumber(data.solvedData[i]);
            gridImages[i].GetComponent<GridSquare>().SetHasDefaultValue(data.unsolvedData[i] != 0 && data.unsolvedData[i] == data.solvedData[i]);
        }
    }

    private void CheckBoardCompleted(int number)
    {
        Invoke("CheckBoardCompletedCheck", 0.5f);
    }
    private void CheckBoardCompletedCheck()
    {
        foreach (var gridImage in gridImages)
        {
            var comp = gridImage.GetComponent<GridSquare>();
            if (comp.IsCorrectNumberSet() == false)
            {
                Debug.Log("wrong answer");
                return;
            }
        }

        GameEvents.OnBoardCompletedMethod();
    }
}
