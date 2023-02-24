using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Head : Cell
{
    [SerializeField]
    private int shift = 50;

    public MapScriptableObject mapData;

    public event Action<Vector3Int> OnRotateSprite = delegate{ };

    public void Awake()
    {
        shift = mapData.grid;

        forward = new Vector3Int(0,shift,0);

        SetForward(forward);
    }

    public override void Move()
    {
        transform.position += forward;
        if (next == null) return;
        next.SetForward(forward);
    }

    public void OnMovement(InputValue input) //Change Vector 'forward'
    {
        if (input == null) return;

        Vector2 inputVec = input.Get<Vector2>();

        if (!IsNewDirectionPerpendicular(inputVec)) return; 

        forward = shift * new Vector3Int((int)inputVec.x, (int)inputVec.y, 0);

        OnRotateSprite(forward);
    }

    public bool IsNewDirectionPerpendicular(Vector3 newDirection)
    {
        return Vector3.Scale(forward, newDirection) == Vector3.zero;
    }

}
