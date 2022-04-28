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

    //has to be inverted for black team (maybe improve later with local movement, the black team is roatad by 180Åã)
    public Vector3 CalculateMovePosition(char direction)
    {
        Vector3 movementAdd = new Vector3(0, 0, 0); //add value to current position, to get new position && pos0,0,0, as default, if no ifcase is true(wrong char direction recived)
        //f-forward, l-left, r-right, b-backward && calculate * 2, because fields have the size of 2,1,2
        if (direction == 'f')
        {
            movementAdd = new Vector3(0, 0, (this.defaultFieldsToMove * 2));
        }
        else if (direction == 'b')
        {
            movementAdd = new Vector3(0, 0, -(this.defaultFieldsToMove * 2));
        }
        else if (direction == 'r')
        {
            movementAdd = new Vector3((this.defaultFieldsToMove * 2), 0, 0);
        }
        else if (direction == 'l')
        {
            movementAdd = new Vector3(-(this.defaultFieldsToMove * 2), 0, 0);
        }

        //Debug.Log("position: " + transform.position);
        Vector3 movePosition = transform.position + movementAdd;
        //Debug.Log("moveToPosition: " + movePosition);
        return movePosition;

    }

    public void MovePice(Vector3 position)
    {
        Vector3 newPosition = position + new Vector3(0, positionOffset, 0);
        transform.position = newPosition;
        DeselectPice();
    }
}

