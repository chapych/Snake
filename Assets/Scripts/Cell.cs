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

    void Start()
    {
        //forward = ;//why awake not working?
        //queue = ;
        StartCoroutine(Movement());
    }
    public void SetForward(Vector3Int forward)
    {
        queue.Enqueue(forward);
    }
    public virtual IEnumerator Movement()
    {
        while (true)
        {
            if (next != null)
                next.SetForward(forward);
            yield return new WaitForSecondsRealtime(timeDelay);
            this.forward = queue.Dequeue();
            Move();
            
        }
    }
    public virtual void Move()
    {
        transform.position += forward;
    }

    //public void AddNext(GameObject _)
    //{
    //    return;
    //}

    public void AddNext(GameObject gameObject)
    {
        Cell next = gameObject.GetComponent<Cell>();
        this.next = next;
        next.SetForward(forward);
    }
}
