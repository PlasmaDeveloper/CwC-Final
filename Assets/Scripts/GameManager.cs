using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //components and objects

    //values
    [SerializeField] bool piceIsSelected;
    [SerializeField] GameObject[] line1;
    [SerializeField] GameObject[] line2;
    [SerializeField] GameObject[] line3;
    [SerializeField] GameObject[] line4;
    [SerializeField] GameObject[] line5;
    [SerializeField] GameObject[] line6;
    [SerializeField] GameObject[] line7;
    [SerializeField] GameObject[] line8;

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
