using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawnable Items", menuName = "Spawnable Items", order = 1)]
public class SpawnableItems : ScriptableObject
{
    public List<ItemPool> Pool;
    public GameObject GetRandomItem()
    {
        foreach (ItemPool item in Pool)
        {
            if(UnityEngine.Random.Range(0, 101)<=item.ChanceToSpawn)
            {
                return item.Prefab;
            }
        }
        return Pool[0].Prefab;
    }
    private double ChanceSum()
    {
        double sum = 0;
        foreach (ItemPool item in Pool) 
        {
            sum += item.ChanceToSpawn;
        }
        return sum;
    }
}
[Serializable]
public class ItemPool
{
    public GameObject Prefab;
    public double ChanceToSpawn;
}