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
    }

    //changes color of current hovered over object, changes back color of previous object before
    private void OnMouseEnter()
    {
        if(!gameManager.GetPiceIsSelected())
        {
            GetComponent<Renderer>().material.color = hoverColor;
            //Debug.Log("Mouse:ObjectEnter");
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
            GetComponent<Renderer>().material.color = teamColor;
            //Debug.Log("Mouse:ObjectExit");
        }

        
    }

    public Vector3 Move(char direction)
    {
        Vector3 movementAdd = new Vector3(0,0,0); //add value to current position, to get new position && pos0,0,0, as default, if no ifcase is true(wrong char direction recived)
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
            movementAdd = new Vector3((this.defaultFieldsToMove * 2),0, 0);
        }
        else if (direction == 'l')
        {
            movementAdd = new Vector3(-(this.defaultFieldsToMove * 2),0, 0);
        }

        //Debug.Log("position: " + transform.position);
        Vector3 movePosition = transform.position + movementAdd;
        //Debug.Log("moveToPosition: " + movePosition);
        return movePosition;

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
        GetComponent<Renderer>().material.color = hoverColor;
        gameManager.SetPiceIsSelected(false, null);
        thisIsSelected = false;
        gameManager.SetReactedToSelection(false);
        gameManager.EndHilightBoardElement();
        //Debug.Log("Mouse:ObjectDeselected");
    }
}

