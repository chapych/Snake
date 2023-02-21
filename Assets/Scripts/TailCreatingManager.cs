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

    public event Action<GameObject> OnSetNewTail = delegate {};
    private void Awake()
    {
        GetComponentInChildren<EatingSystem>().OnAddNewTail += HandlerOnAddNewTail;
    }

    
    private void HandlerOnAddNewTail()
    {
        prefab.SetActive(true);
        Vector3Int spawnPosition = Vector3Int.FloorToInt(tail.transform.position);
        StartCoroutine(WaitTillRestBodyMoved(spawnPosition));
        

    }

    IEnumerator WaitTillRestBodyMoved(Vector3 spawnPosition)
    {
        yield return new WaitForSecondsRealtime(tail.GetComponent<Cell>().timeDelay);
        var newTail = Instantiate(prefab, spawnPosition, Quaternion.identity);
        OnSetNewTail(newTail);
        tail = newTail;
        newTail.transform.parent = this.transform;
    }
}
