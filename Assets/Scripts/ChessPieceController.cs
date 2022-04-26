using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceController : MonoBehaviour
{
    //!!!AD CHECK FOR ANY OTHER OBJECT IN SCENE SELECTED!!! in onMouseEnter

    //components and objects
    [SerializeField] Color teamColor;

    //values
    //only serializeField, to check in inspector, dont set vaules there!
    Vector3 position;
    bool isSelected;
    Color hoverColor = new Color(1, 0.92f, 0.016f, 1);
    Color selectionColor = new Color(1,0,0,1);


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
        isSelected = false;
    }

    //changes color of current hovered over object, changes back color of previous object before
    private void OnMouseEnter()
    {
        if(!isSelected) //!!!AD CHECK FOR ANY OTHER OBJECT IN SCENE SELECTED!!!
        {
            GetComponent<Renderer>().material.color = hoverColor;
            Debug.Log("Enter");

        }
        

        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isSelected)
        {
            GetComponent<Renderer>().material.color = selectionColor;
            isSelected = true;
            Debug.Log("Selected");
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && isSelected)
        {
            GetComponent<Renderer>().material.color = hoverColor;
            isSelected = false;
            Debug.Log("Deselected");

        }
    }

    private void OnMouseExit()
    {
        if (!isSelected)
        {
            GetComponent<Renderer>().material.color = teamColor;
            Debug.Log("Exit");
        }

        
    }
}
