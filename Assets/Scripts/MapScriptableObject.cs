using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MapScriptableObject", order = 1)]
public class MapScriptableObject : ScriptableObject
{
    public int width;
    public int height;
    public int grid;
}