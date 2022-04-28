using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : ChessPieceController
{
    // Start is called before the first frame update
    void Start()
    {
        ObjectSetup();
        moveDirections.Add('b');
        moveDirections.Add('l');
        moveDirections.Add('r');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
