using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            FindObjectOfType<CameraMovement2>().enabled = true;
        }
        
    }
}
