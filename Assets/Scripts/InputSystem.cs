using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private Head head;
    void Start()
    {
        head = GetComponent<Head>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //    head.TurnLeft();
        //if(Input.GetKeyDown(KeyCode.RightArrow))
        //    head.TurnRight();
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //    head.TurnUp();
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //    head.TurnDown();
    }

}
