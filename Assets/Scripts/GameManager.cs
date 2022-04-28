using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //components and objects

    //values
    bool piceIsSelected;
    bool reactedToSelection; //if Programm already has responded to a selected pice
    bool reactedToSelectionCapture; //if Programm has already respondet to a selected pice with highlighting capture fields
    GameObject selectedPiece;
    GameObject highlightedField;

    //dont delete SerializeFiled - not for test-viewing in Inspector, but for code functionality
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
        //HighlightFieldsToCaptureOn();
    }

    void SetUpGameManager()
    {
        this.reactedToSelection = false;
    }

    //when chess pice is selected, this calculates all board elements, you could move to
    //!!!currently hardcoded with only move forward, has to get the posible movement directions from ChessPiceController later!!!
    private void HighlightFieldsToMove()
    {
        List<Vector3> highlightPosition = new List<Vector3>();
        List<GameObject[]> linesToUse = new List<GameObject[]>();

        if (piceIsSelected && !reactedToSelection)
        {
            highlightPosition.AddRange(selectedPiece.GetComponent<ChessPieceController>().CalculateMovePosition());

            foreach (Vector3 hPosition in highlightPosition)
            {
                linesToUse.Add(ScanForRightLine(hPosition));
            }

            foreach (GameObject[] line in linesToUse)
            {
                foreach (GameObject boardField in line)
                {
                    foreach (Vector3 hPosition in highlightPosition)
                    {
                        if (boardField.transform.position.x == hPosition.x && !boardField.GetComponent<BoardController>().GetIsOccupied())
                        {
                            HighlightBoardElement(boardField);
                        }
                    }

                    
                }
            }
            reactedToSelection = true;
        }

    }

    /*private void HighlightFieldsToCaptureOn()
    {
        List<Vector3> highlightPosition = new List<Vector3>();
        List<GameObject[]> linesToUse = new List<GameObject[]>();

        if (piceIsSelected && !reactedToSelectionCapture)
        {
            highlightPosition.AddRange(selectedPiece.GetComponent<ChessPieceController>().CalculateCapturePosition());

            foreach (Vector3 hPosition in highlightPosition)
            {
                linesToUse.Add(ScanForRightLine(hPosition));
            }

            foreach (GameObject[] line in linesToUse)
            { 
                foreach (GameObject boardField in line)
                {
                    foreach (Vector3 hPosition in highlightPosition)
                    {
                        if (boardField.transform.position.x == hPosition.x && boardField.GetComponent<BoardController>().GetIsOccupied())
                        {
                            HighlightBoardElement(boardField);
                        }
                    }

                }
            }

            reactedToSelectionCapture = true;

        }
    }*/

    //Returns the line(list with GameObjects), where the board element to move to must be located
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

    void HighlightBoardElement(GameObject boardElement)
    {
        //Debug.Log("HighlightRun");
        boardElement.GetComponent<Renderer>().material.color = boardElement.GetComponent<BoardController>().GetHighlightColor();
        boardElement.GetComponent<BoardController>().SetThisIsHighlighted(true);
        highlightedField = boardElement;
    }

    //bridge between BoardController (on mousehoover + klick) and ChessPiceController(to move it)
    public void ManageMovement(Vector3 position)
    {
        selectedPiece.GetComponent<ChessPieceController>().MovePice(position);
    }

    public void EndHighlightBoardElement()
    {
        if (highlightedField != null)
        {
            GameObject boardElement = highlightedField;
            boardElement.GetComponent<BoardController>().SetThisIsHighlighted(false);
            boardElement.GetComponent<Renderer>().material.color = boardElement.GetComponent<BoardController>().GetBoardColor();

        }
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

    public void SetReactedToSelection(bool value)
    {
        this.reactedToSelection = value;
    }
}
