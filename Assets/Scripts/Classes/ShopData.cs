using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ShopData
{
    public int equippedIndex;
    public List<Item> data;

    public ShopData()
    {
        data = new List<Item>();
        equippedIndex = 0;
    }

    public ShopData(int equippedIndex, List<Item> data)
    {
        this.equippedIndex = equippedIndex;
        this.data = data;
    }

    public void SaveShopData()
    {
        string path = GetPersistentPath();

        if (!string.IsNullOrEmpty(path))
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(path, json);
        }
        else
        {
            Debug.LogError("Could not get the persistent path for saving ShopData.");
        }
    }

    public static ShopData LoadShopData()
    {
        string path = GetPersistentPath();

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<ShopData>(json);
        }
        else
        {
            return null;
        }
    }

    private static string GetPersistentPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Path.Combine(Application.persistentDataPath, "ShopData.json");
#else
        return Path.Combine(Application.dataPath, "ShopData.json");
#endif
    }
}

[Serializable]
public class Item
{
    public int id;
    public int itemId;

    public Item()
    {
        id = 0;
        itemId = 0;
    }

    public Item(int id, int itemId)
    {
        this.id = id;
        this.itemId = itemId;
    }
}
