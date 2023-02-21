using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Head : Cell
{
    
    private void Start()
    {
        forward = new Vector3Int(0, 10);
        StartCoroutine(Movement());
    }
    
    public override IEnumerator Movement()
    {
        while (true)
        {
            Move();
            if(next!=null)
                next.SetForward(forward);
            yield return new WaitForSecondsRealtime(timeDelay);
        }
    }

    public override void Move()
    {
        base.Move();
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
