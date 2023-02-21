using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICell 
{
    void AddNext(GameObject _);

    public void SetForward(Vector3Int _);

    IEnumerator Movement();

    void Move();
    
}
