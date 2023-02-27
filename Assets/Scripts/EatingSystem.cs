using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EatingSystem : MonoBehaviour
{
    public event Action OnAddNewTail = delegate { };
    public event Action OnEndGame = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ICell>(out ICell cell))
        {
            OnEndGame();
            SceneManager.LoadScene("Game");
        }
        ICollectable item = collision.gameObject.GetComponent<ICollectable>();
        if (item == null) return;
        OnAddNewTail();
        item.Destroy();
    }
}

    