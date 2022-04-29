using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceController : MonoBehaviour
{
    //components and objects
    protected Color teamColor;
    protected GameManager gameManager;

    //values
    protected Color hoverColor = new Color(1, 0.92f, 0.016f, 1);
    protected Color selectionColor = new Color(1, 0, 0, 1);
    protected bool thisIsSelected;

    protected List<int> defaultFieldsToMove = new List<int>();
    protected List<char> moveDirections = new List<char>(); //where it can move to, default object can only move forward
    //int defaultCaptureMove = 1; //field to move when able to capture
    //char[] captureDirections = {'f'}; //in which direction it can capture enemies
    protected float positionOffset;


    // Start is called before the first frame update
    void Start()
    {
        ObjectSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void ObjectSetup()
    {
        teamColor = GetComponent<Renderer>().material.color;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisIsSelected = false;
        positionOffset = transform.position.y;
        defaultFieldsToMove.Add(1);
        moveDirections.Add('f');
    }

    //changes color of current hovered over object, changes back color of previous object before
    private void OnMouseEnter()
    {
        if (!gameManager.GetPiceIsSelected())
        {
            //Debug.Log("Mouse:ObjectEnter");
            HooverPice();
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
        HooverPice();
        thisIsSelected = false;
        gameManager.SetPiceIsSelected(false, null);
        gameManager.SetReactedToSelection(false);
        gameManager.EndHighlightBoardElement();
        //Debug.Log("Mouse:ObjectDeselected");
    }

    private void HooverPice()
    {
        GetComponent<Renderer>().material.color = hoverColor;
    }

    private void EndHooverPice()
    {
        GetComponent<Renderer>().material.color = teamColor;
    }

    //has to be inverted for black team (maybe improve later with local movement, the black team is roatad by 180Åã)
    //returns List type Vector3 with all possible positions where the pice can move to
    public virtual List<Vector3> CalculateMovePosition()
    {
        List<Vector3> movePosition = new List<Vector3>();

        foreach (char direction in moveDirections)
        {

            foreach (int moveSteps in defaultFieldsToMove)
            {


                Vector3 movementAdd = new Vector3(0, 0, 0); //add value to current position, to get new position && pos0,0,0, as default, if no ifcase is true(wrong char direction recived)
               //f-forward, l-left, r-right, b-backward && calculate * 2, because fields have the size of 2,1,2
               //diagonal movement is inspired by the (german) keyboard layout
               //q-forward left e-forward right y-backward left c-backward right

                switch (direction)
                {
                    case 'f':
                        movementAdd = new Vector3(0, 0, (moveSteps * 2));
                        break;
                    case 'b':
                        movementAdd = new Vector3(0, 0, -(moveSteps * 2));
                        break;
                    case 'l':
                        movementAdd = new Vector3((moveSteps * 2), 0, 0);
                        break;
                    case 'r':
                        movementAdd = new Vector3(-(moveSteps * 2), 0, 0);
                        break;
                    case 'q':
                        movementAdd = new Vector3((moveSteps * 2),0,(moveSteps * 2));
                        break;
                    case 'e':
                        movementAdd = new Vector3(-(moveSteps * 2), 0, (moveSteps * 2));
                        break;
                    case 'y':
                        movementAdd = new Vector3((moveSteps * 2), 0, -(moveSteps * 2));
                        break;
                    case 'c':
                        movementAdd = new Vector3(-(moveSteps * 2), 0, -(moveSteps * 2));
                        break;
                    default:
                        break;


                }

                movePosition.Add(transform.position + movementAdd);
            }

        }

        return movePosition;

    }

    //has to be inverted for black team (maybe improve later with local movement, the black team is roatad by 180Åã)
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

