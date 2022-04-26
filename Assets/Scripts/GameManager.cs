using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //components and objects

    //values
    [SerializeField] bool piceIsSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetPiceIsSelected()
    {
        return this.piceIsSelected;
    }

    public void SetPiceIsSelected(bool piceIS)
    {
        this.piceIsSelected = piceIS;
    }
}
