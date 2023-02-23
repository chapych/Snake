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
        var spawnCount = spawningObjects.Length;
        int horsontal = Random.Range(-width, width);////поделить на размер сетки
        int vertical = Random.Range(-height, height);
        int spawningNumber = Random.Range(0, spawnCount);

        GameObject gameObject = Instantiate(spawningObjects[spawningNumber], new Vector3Int(horsontal, vertical), Quaternion.identity);
        isAplleOnScreen = true;
    }

    void HandlerOnAddNewTail()
    {
        isAplleOnScreen = false;
    }


}
