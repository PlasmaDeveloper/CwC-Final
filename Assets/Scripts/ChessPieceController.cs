using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceController : MonoBehaviour
{
    //components and objects
    Color teamColor;
    GameManager gameManager;

    //values
    Color hoverColor = new Color(1, 0.92f, 0.016f, 1);
    Color selectionColor = new Color(1,0,0,1);
    bool thisIsSelected;

    int defaultFieldsToMove = 1;
    char[] moveDirections = {'f'}; //where it can move to, default object can only move forward
    //int defaultCaptureMove = 1; //field to move when able to capture
    //char[] captureDirections = {'f'}; //in which direction it can capture enemies
    float positionOffset;


    // Start is called before the first frame update
    void Start()
    {
        ObjectSetup();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ObjectSetup()
    {
        teamColor = GetComponent<Renderer>().material.color;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisIsSelected = false;
        positionOffset = transform.position.y;
    }

    //changes color of current hovered over object, changes back color of previous object before
    private void OnMouseEnter()
    {
        if(!gameManager.GetPiceIsSelected())
        {
            //Debug.Log("Mouse:ObjectEnter");
            HoovertPice();
        }
        

        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameManager.GetPiceIsSelected())
        {
            SelectPice();
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && gameManager.GetPiceIsSelected() && this.thisIsSelected)
        {
            DeselectPice();
        }
    }

    private void OnMouseExit()
    {
        if (!gameManager.GetPiceIsSelected())
        {
            //Debug.Log("Mouse:ObjectExit");
            EndHooverPice();
        }

        
    }

    private void SelectPice()
    {
        GetComponent<Renderer>().material.color = selectionColor;
        gameManager.SetPiceIsSelected(true, this.gameObject);
        thisIsSelected = true;
        //Debug.Log("Mouse:ObjectSelected");
    }

    private void DeselectPice()
    {
        HoovertPice();
        thisIsSelected = false;
        gameManager.SetPiceIsSelected(false, null);
        gameManager.SetReactedToSelection(false);
        gameManager.EndHighlightBoardElement();
        //Debug.Log("Mouse:ObjectDeselected");
    }

    private void HoovertPice()
    {
        GetComponent<Renderer>().material.color = hoverColor;
    }

    private void EndHooverPice()
    {
        GetComponent<Renderer>().material.color = teamColor;
    }

    //has to be inverted for black team (maybe improve later with local movement, the black team is roatad by 180��)
    //returns List type Vector3 with all possible positions where the pice can move to
    public List<Vector3> CalculateMovePosition()
    {
        List<Vector3> movePosition = new List<Vector3>();

        foreach (char direction in moveDirections)
        {

            Vector3 movementAdd = new Vector3(0, 0, 0); //add value to current position, to get new position && pos0,0,0, as default, if no ifcase is true(wrong char direction recived)
                                                        //f-forward, l-left, r-right, b-backward && calculate * 2, because fields have the size of 2,1,2
            if (direction == 'f')
            {
                movementAdd = new Vector3(0, 0, (defaultFieldsToMove * 2));
            }
            else if (direction == 'b')
            {
                movementAdd = new Vector3(0, 0, -(defaultFieldsToMove * 2));
            }
            else if (direction == 'r')
            {
                movementAdd = new Vector3((defaultFieldsToMove * 2), 0, 0);
            }
            else if (direction == 'l')
            {
                movementAdd = new Vector3(-(defaultFieldsToMove * 2), 0, 0);
            }

            movePosition.Add(transform.position + movementAdd);
        }

        return movePosition;

    }

    //has to be inverted for black team (maybe improve later with local movement, the black team is roatad by 180��)
    //returns List type Vector3 with all possible positions where the pice can move to, when occupied by an enemy
    /*public List<Vector3> CalculateCapturePosition()
    {
        List<Vector3> capturePosition = new List<Vector3>();

        Vector3 captureMovementAdd = new Vector3(0, 0, 0);

        foreach (char direction in captureDirections)
        {
            if (direction == 'f')
            {
                captureMovementAdd = new Vector3(0, 0, (defaultCaptureMove * 2));
            }
            else if (direction == 'b')
            {
                captureMovementAdd = new Vector3(0, 0, -(defaultCaptureMove * 2));
            }
            else if (direction == 'r')
            {
                captureMovementAdd = new Vector3((defaultCaptureMove * 2), 0, 0);
            }
            else if (direction == 'l')
            {
                captureMovementAdd = new Vector3(-(defaultCaptureMove * 2), 0, 0);
            }

            capturePosition.Add(transform.position + captureMovementAdd);
        }

        return capturePosition;
    }*/

    public void MovePice(Vector3 position)
    {
        Vector3 newPosition = position + new Vector3(0, positionOffset, 0);
        transform.position = newPosition;
        DeselectPice();
    }
}

