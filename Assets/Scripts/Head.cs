using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Head : Cell
{

    //private void Start()
    //{
    //    GetComponentInParent<TailCreatingManager>().OnSetNewTail += AddNext;
    //    forward = new Vector3Int(0, 10);
    //}
    public void Awake()
    {
        forward = new Vector3Int(0,10,0);
        SetForward(forward);

    }

    public override void Move()
    {
        transform.position += forward;
        if (next == null) return;
        next.SetForward(forward);
    }

    
    internal void TurnRight()
    {
        forward.y = 0;
        forward.x=10;
    }

    internal void TurnLeft()
    {
        forward.y = 0;
        forward.x=-10;
    }

    internal void TurnUp()
    {
        forward.x = 0;
        forward.y=10;
    }
    internal void TurnDown()
    {
        forward.x = 0;
        forward.y=-10;
    }

}
