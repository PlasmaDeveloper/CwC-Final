using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    //components and objects
    Color boardColor;
    GameManager gameManager;

    //values
    bool thisIsHighlighted;
    [SerializeField] bool isOccupied;
    Color hoverColor = new Color(1, 0.92f, 0.016f, 1);
    Color highlightColor = new Color(1, 0, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        ObjectSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ObjectSetup()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisIsHighlighted = false;
        boardColor = GetComponent<Renderer>().material.color;
        //Debug.Log("Color: " + boardColor);
    }
    private void OnMouseEnter()
    {
        if (thisIsHighlighted)
        {
            HooverBoardElement();
        }
    }

    private void OnMouseOver()
    {
        if (thisIsHighlighted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameManager.ManageMovement(transform.position);
        }
    }

    private void OnMouseExit()
    {
        if (thisIsHighlighted)
        {
            EndHooverBoardElement();
            //gameManager.EndHighlightBoardElement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Enter");
        isOccupied = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Trigger Exit");
        isOccupied = false;
    }

    private void HooverBoardElement()
    {
        GetComponent<Renderer>().material.color = hoverColor;
    }

    private void EndHooverBoardElement()
    {
        GetComponent<Renderer>().material.color = highlightColor;
    }

    public void SetThisIsHighlighted(bool tIH)
    {
        this.thisIsHighlighted = tIH;
    }

    public bool GetThisIsHighlighted()
    {
        return this.thisIsHighlighted;
    }

    public Color GetHighlightColor()
    {
        return this.highlightColor;
    }

    public Color GetBoardColor()
    {
        return this.boardColor;
    }

    public bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void SetIsOccupied(bool  oc)
    {
        this.isOccupied = oc;
    }
}
