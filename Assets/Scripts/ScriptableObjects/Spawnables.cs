using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level beh", menuName = "Spawnables", order = 1)]
public class Spawnables : ScriptableObject
{
    public List<spawnItem> spawnItems;
}
[System.Serializable]
public class spawnItem
{
    public string name;
    public GameObject itemObject;
    public float probabitly;
}
