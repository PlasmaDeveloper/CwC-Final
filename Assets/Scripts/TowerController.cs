using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : ChessPieceController
{
    // Start is called before the first frame update
    void Start()
    {
        TowerSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TowerSetup()
    {
        ObjectSetup();

        defaultFieldsToMove.Add(1);
        defaultFieldsToMove.Add(2);
        defaultFieldsToMove.Add(3);
        defaultFieldsToMove.Add(4);
        defaultFieldsToMove.Add(5);
        defaultFieldsToMove.Add(6);
        defaultFieldsToMove.Add(7);
        defaultFieldsToMove.Add(8);

        moveDirections.Add('l');
        moveDirections.Add('r');
        moveDirections.Add('b');
    }

    public override List<Vector3> CalculateMovePosition()
    {
        List<Vector3> movePosition = new List<Vector3>();

        movePosition.AddRange(base.CalculateMovePosition());

        return movePosition;
    }
}
