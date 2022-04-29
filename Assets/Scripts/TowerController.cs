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

        moveDirections.Add('b');
        moveDirections.Add('l');
        moveDirections.Add('r');
    }

    /*public override List<Vector3> CalculateMovePosition()
    {
        List<Vector3> movePosition = new List<Vector3>();

        movePosition.AddRange(base.CalculateMovePosition());

        return movePosition;
    }*/
}
