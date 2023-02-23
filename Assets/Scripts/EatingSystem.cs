using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EatingSystem : MonoBehaviour
{
    public event Action OnAddNewTail = delegate { };
    public event Action OnEndGame = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ICell>(out ICell cell))
        {
            OnEndGame();
            Debug.Log("End");
        }
        ICollectable item = collision.gameObject.GetComponent<ICollectable>();
        if (item == null) return;
        OnAddNewTail();
        item.Destroy();
    }
}

    