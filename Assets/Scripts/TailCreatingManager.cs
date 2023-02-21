using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            renderer = value.GetComponent<Renderer>();
            tail = value; 
        }
    }
    private Renderer renderer;

    private void Awake()
    {
        GetComponentInChildren<EatingSystem>().OnAddNewTail += HandlerOnAddNewTail;
        renderer = tail.GetComponent<Renderer>();
    }

    
    private void HandlerOnAddNewTail()
    {
        prefab.SetActive(true);
        Vector3Int spawnPosition = Vector3Int.FloorToInt(tail.transform.position);
        Debug.Log(spawnPosition.y);
        StartCoroutine(WaitTillRestBodyMoved(spawnPosition));
        

    }

    IEnumerator WaitTillRestBodyMoved(Vector3 spawnPosition)
    {
        yield return new WaitForSecondsRealtime(tail.GetComponent<Cell>().timeDelay);
        var newTail = Instantiate(prefab, spawnPosition, Quaternion.identity);

        tail.GetComponent<Cell>().AddNext(newTail);
        tail = newTail;
    }
}
