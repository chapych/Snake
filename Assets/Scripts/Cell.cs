using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell : MonoBehaviour, ICell
{

    private Cell previous;
    [SerializeField]
    internal Cell next;
    [SerializeField]
    internal Vector3Int forward=new Vector3Int(0,0,0);
    [SerializeField]
    public int timeDelay = 1;
    internal Queue<Vector3Int> queue=new Queue<Vector3Int>();

    

    public void Start()
    {
        GetComponentInParent<TailCreatingManager>().OnAddCell += AddNext;

        GetComponentInParent<MovementManager>().OnMove += Move;
    }
    public void SetForward(Vector3Int forward)
    {
        queue.Enqueue(forward);
    }
    
    public virtual void Move()
    {
        forward = queue.Dequeue();
        transform.position += forward;
        if (next == null) return;
        next.SetForward(forward);
    }


    public void AddNext(GameObject gameObject)
    {
        if (next != null) return;
        Cell nextCell = gameObject.GetComponent<Cell>();
        this.next = nextCell;
        next.SetForward(forward);
        Debug.Log(forward);
    }
}
