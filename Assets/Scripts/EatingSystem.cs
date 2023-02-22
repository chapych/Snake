using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EatingSystem : MonoBehaviour
{
    public event Action OnAddNewTail = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable item = collision.gameObject.GetComponent<ICollectable>();
        if (item == null) return;
        OnAddNewTail();
        item.Destroy();
    }
}

    