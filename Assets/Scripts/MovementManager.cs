using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    private int timeDelay = 1;
    Coroutine coroutine;
    public event Action OnMove = delegate { };

    void Start()
    {
        coroutine = StartCoroutine(SnakeMovement()); //refresh the list if a new item is added
    }


    public IEnumerator SnakeMovement() 
    {
        while (true)
        {
            OnMove();
            yield return new WaitForSecondsRealtime(timeDelay);
        }
    }

    
}
