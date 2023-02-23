using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Head : Cell
{
    public int shift = 50;
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
        forward.x=shift;
    }

    internal void TurnLeft()
    {
        forward.y = 0;
        forward.x=-shift;
    }

    internal void TurnUp()
    {
        forward.x = 0;
        forward.y=shift;
    }
    internal void TurnDown()
    {
        forward.x = 0;
        forward.y=-shift;
    }

}
