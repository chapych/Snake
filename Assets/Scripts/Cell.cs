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
    private Queue<Vector3Int> queue=new Queue<Vector3Int>();

    public void Start()
    {
        GetComponentInParent<TailCreatingManager>().OnSetNewTail += AddNext;
        forward = new Vector3Int(0, 0, 0);
    }
    public void SetForward(Vector3Int forward)
    {
        queue.Enqueue(forward);
    }
    
    public virtual void Move()
    {
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
    }
}
