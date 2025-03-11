using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData
{
    private static GameData _instance;
    //Items
    public string EquippedAnimal;
    public string EquippedCart;

    public List<string> OwnedAnimals;
    public List<string> OwnedCarts;
    public List<string> OwnedSpecialItems;

    //Settings
    public int Volume;
    public int Sound;

    //Score
    public int Distance = 0;

    //Shop
    public int Coins = 0;

    private GameData() {
        EquippedAnimal = "DefaultAnimal";
        EquippedCart = "DefaultCart";
        OwnedAnimals = new List<string>();
        OwnedCarts = new List<string>();
        OwnedAnimals.Add(EquippedAnimal);
        OwnedCarts.Add(EquippedCart);
        OwnedSpecialItems = new List<string>();
        Volume = 100;
        Sound = 100; 
    }
    public static GameData GetInstance()
    {
        if (_instance == null)
        {
            _instance = Load();
        }
        return _instance;
    }


    public void Save()
    {
        string path = GetPersistentPath();

        if (!string.IsNullOrEmpty(path))
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(path, json);
        }
        else
        {
            Debug.LogError("Could not get the persistent path for saving settings.");
        }
    }

    private static GameData Load()
    {
        string path = GetPersistentPath();

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            return new GameData();
        }
    }

    private static string GetPersistentPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Path.Combine(Application.persistentDataPath, "GameData.json");
#else
        return Path.Combine(Application.dataPath, "GameData.json");
#endif
    }
}
