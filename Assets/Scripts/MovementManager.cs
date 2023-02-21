using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    private int timeDelay = 1;
    HashSet<Cell> ellList = new HashSet<Cell>();
    Coroutine coroutine; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<TailCreatingManager>().OnSetNewTail += AddToList;
        FindAllObjectsWIthParticularInterface<Cell>(ellList);
        coroutine = StartCoroutine(SnakeMovement()); //refresh the list if a new item is added
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SnakeMovement() 
    {
        while (true)
        {
        FindAllObjectsWIthParticularInterface<Cell>(ellList);
            Debug.Log(ellList.Count() + "!!!!!");
        foreach(var cell in ellList)
        {
            cell.Move();
            yield return new WaitForSecondsRealtime(timeDelay);
        }

        }
        
    }

    public void FindAllObjectsWIthParticularInterface<T>(HashSet<T> list)
    {
        
        foreach(var gameObject in this.GetComponentsInChildren<T>())
        {
                list.Add(gameObject);
        }
    }

    public void AddToList(GameObject element) 
    {
        //var newElement = element.GetComponent<Cell>();
        //StopCoroutine(coroutine);
        //ellList.Add(newElement);
        //coroutine = StartCoroutine(SnakeMovement());
    }
}
