using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TailCreatingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tail;
    [SerializeField]
    private GameObject prefab;
    public GameObject Tail
    {
        get { return tail; }
        set 
        { 
            tail = value; 
        }
    }

    public event Action<GameObject> OnAddCell = delegate {};
    private void Awake()
    {
        GetComponentInChildren<EatingSystem>().OnAddNewTail += HandlerOnAddNewTail;
    }

    
    private void HandlerOnAddNewTail()
    {
        Vector3Int spawnPosition = Vector3Int.FloorToInt(tail.transform.position);
        StartCoroutine(WaitTillRestBodyMoved(spawnPosition));
    }

    IEnumerator WaitTillRestBodyMoved(Vector3 spawnPosition)
    {
        yield return new WaitForSecondsRealtime(tail.GetComponent<Cell>().timeDelay);
        var newTail = Instantiate(prefab, spawnPosition, Quaternion.identity);
        newTail.transform.parent = this.transform;
        Debug.Log(newTail.transform.parent.name + "??" + tail.name);
        OnAddCell(newTail);
        tail = newTail;
        
    }
}
