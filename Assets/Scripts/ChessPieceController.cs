using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceController : MonoBehaviour
{
    //components and objects
    Color teamColor;
    GameManager gameManager;

    //values
    Vector3 position;
    Color hoverColor = new Color(1, 0.92f, 0.016f, 1);
    Color selectionColor = new Color(1,0,0,1);
    bool thisIsSelected;


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
            Debug.Log("Enter");

        }
        

        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameManager.GetPiceIsSelected())
        {
            GetComponent<Renderer>().material.color = selectionColor;
            gameManager.SetPiceIsSelected(true);
            this.thisIsSelected = true;
            Debug.Log("Selected");
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && gameManager.GetPiceIsSelected() && this.thisIsSelected)
        {
            GetComponent<Renderer>().material.color = hoverColor;
            gameManager.SetPiceIsSelected(false);
            this.thisIsSelected = false;
            Debug.Log("Deselected");

        }
    }

    private void OnMouseExit()
    {
        if (!gameManager.GetPiceIsSelected())
        {
            GetComponent<Renderer>().material.color = teamColor;
            Debug.Log("Exit");
        }

        
    }
}
