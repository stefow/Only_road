using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawnable Items", menuName = "Spawnable Items", order = 1)]
public class SpawnableItems : ScriptableObject
{
    public List<ItemPool> Pool;
    public ItemPool GetRandomItem()
    {
        int random = UnityEngine.Random.Range(0, TotalChance());
        int currentChance = 0;
        foreach (ItemPool item in Pool)
        {
            currentChance += item.SpawnChance;
            if (random < currentChance) return item;
        }
        return Pool[0];
    }
    private int TotalChance()
    {
        int sum = 0;
        foreach (ItemPool item in Pool)
        {
            sum += item.SpawnChance;
        }
        return sum;
    }
}
[Serializable]
public class ItemPool
{
    public GameObject Prefab;
    public int SpawnChance;

}