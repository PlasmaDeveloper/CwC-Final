using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //components and objects

    //values
    bool piceIsSelected;
    bool reactedToSelection;
    GameObject selectedPiece;
    GameObject highlightedField;

    //dont deleat SerializeFiled - trust me, you will regret it
    [SerializeField] GameObject[] line1;
    [SerializeField] GameObject[] line2;
    [SerializeField] GameObject[] line3;
    [SerializeField] GameObject[] line4;
    [SerializeField] GameObject[] line5;
    [SerializeField] GameObject[] line6;
    [SerializeField] GameObject[] line7;
    [SerializeField] GameObject[] line8;

    // Start is called before the first frame update
    void Start()
    {
        SetUpGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        HighlightFieldsToMove();
    }

    void SetUpGameManager()
    {
        this.reactedToSelection = false;
    }

    public bool GetPiceIsSelected()
    {
        return this.piceIsSelected;
    }

    public void SetPiceIsSelected(bool piceIS, GameObject selection)
    {
        this.piceIsSelected = piceIS;
        this.selectedPiece = selection;
    }

    private void HighlightFieldsToMove()
    {
        if (piceIsSelected && !reactedToSelection)
        {
            Vector3 highlightPosition = selectedPiece.GetComponent<ChessPieceController>().Move('f');
            //Debug.Log("GameControllerPositionToHilight" + highlightPosition);
            GameObject[] lineToUse = ScanForRightLine(highlightPosition);
            //Debug.Log("GameControllerLineToUse: " + lineToUse);
            foreach (GameObject boardField in lineToUse)
            {
                if (boardField.transform.position.x == highlightPosition.x)
                {
                    HiglightBoardElement(boardField);
                }
            }

            reactedToSelection = true;
        }

    }

    private GameObject[] ScanForRightLine(Vector3 rightPosition)
    {
        //Debug.Log("GameController rightLineInFunctionFULL:" + rightPosition); //currently working
        //Debug.Log("GameController rightLineInFunctionZ: " + rightPosition.z); //seems to be full numbers, no float
        GameObject[] lineToUse;
        switch (rightPosition.z)
        {
            case 0:
                lineToUse = line1;
                //Debug.Log("Case0: " + lineToUse);
                break;
            case 2:
                lineToUse = line2;
                //Debug.Log("Case2: " + lineToUse);
                break;
            case 4:
                lineToUse = line3;
                //Debug.Log("Case4: " + lineToUse);
                break;
            case 6:
                lineToUse = line4;
                //Debug.Log("Case6: " + lineToUse);
                break;
            case 8:
                lineToUse = line5;
                //Debug.Log("Case8: " + lineToUse);
                break;
            case 10:
                lineToUse = line6;
                //Debug.Log("Case10: " + lineToUse);
                break;
            case 12:
                lineToUse = line7;
                //Debug.Log("Case12: " + lineToUse);
                break;
            case 14:
                lineToUse = line8;
                //Debug.Log("Case14: " + lineToUse);
                break;
            default:
                lineToUse = null;
                Debug.Log("DefaultCase - something went wrong"); //Maybe add an exception
                break;
        }

        return lineToUse;
    }

    public void SetReactedToSelection(bool value)
    {
        this.reactedToSelection = value;
    }

    void HiglightBoardElement(GameObject boardElement)
    {
        //Debug.Log("HilightRun");
        boardElement.GetComponent<Renderer>().material.color = boardElement.GetComponent<BoardController>().GetHighlightColor();
        boardElement.GetComponent<BoardController>().SetThisIsHighlighted(true);
        highlightedField = boardElement;
    }

    public void EndHilightBoardElement()
    {
        if (highlightedField != null)
        {
            GameObject boardElement = highlightedField;
            boardElement.GetComponent<BoardController>().SetThisIsHighlighted(false);
            boardElement.GetComponent<Renderer>().material.color = boardElement.GetComponent<BoardController>().GetBoardColor();

        }
    }
}
