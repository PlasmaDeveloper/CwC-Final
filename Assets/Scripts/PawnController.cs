using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : ChessPieceController
{
    //components and gameobjects

    //values
    [SerializeField] bool firstMove;  //special conditions, if first move

    // Start is called before the first frame update
    void Start()
    {
        ObjectSetup();
        defaultFieldsToMove.Add(1);
        defaultFieldsToMove.Add(2);
        firstMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override List<Vector3> CalculateMovePosition()
    {
        List<Vector3> movePosition = new List<Vector3>();

        if (!firstMove)
        {
            defaultFieldsToMove.Remove(2);

        }
        else
        {
            firstMove = false;
        }

        movePosition.AddRange(base.CalculateMovePosition());
        return movePosition;
    }
}
