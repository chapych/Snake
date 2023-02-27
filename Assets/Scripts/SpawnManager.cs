using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawningObjects;
    public MapScriptableObject mapData;
    [SerializeField]
    private bool isAplleOnScreen = false;
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject snake;

    private void Start()
    {
        head.GetComponent<EatingSystem>().OnAddNewTail += HandlerOnAddNewTail;
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
        Spawn();
        yield return new WaitForSeconds(3);
        }
    }
    void Spawn()
    {;
        if (isAplleOnScreen) return;
        int width = mapData.width;
        int height = mapData.height;
        int grid = mapData.grid;
        var spawnCount = spawningObjects.Length;
        int horizontal;
        int vertical;
        do
        {
            horizontal = grid * Random.Range(-width / grid, width / grid);////поделить на размер сетки
            vertical = grid * Random.Range(-height / grid, height / grid);
        } while (!IsCellFree(horizontal, vertical));
        int spawningNumber = Random.Range(0, spawnCount);

        GameObject gameObject = Instantiate(spawningObjects[spawningNumber], new Vector3Int(horizontal, vertical), Quaternion.identity);
        isAplleOnScreen = true;
    }

    void HandlerOnAddNewTail()
    {
        isAplleOnScreen = false;
    }

    bool IsCellFree(int horizontal, int vertical)
    {
        foreach(var cell in snake.GetComponentsInChildren<Cell>())
        {
            if (horizontal == cell.transform.position.x)
                if (vertical == cell.transform.position.y)
                    return false;
        }
        return true;
    }


}
