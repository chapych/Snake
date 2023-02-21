using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICell 
{
    public void AddNext(GameObject _);

    public void SetForward(Vector3Int _);

    void Move();
    
}
