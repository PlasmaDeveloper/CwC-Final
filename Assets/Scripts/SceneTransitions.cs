using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //Ah yes, I forgot to rename the Scene, so whatever.  SampleScene it is then...
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
