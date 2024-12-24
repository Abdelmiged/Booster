using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuittingApplication : MonoBehaviour
{
    void Update()
    {
        QuitApplicaton();
    }

    void QuitApplicaton(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
