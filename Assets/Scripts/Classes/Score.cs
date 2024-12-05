using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Score
{
    public double maxDistance;
    public int totalCoins;
    public Score()
    {
        maxDistance = 0;
        totalCoins = 0;
    }
    public Score(double maxScore, int totalCoins)
    {
        this.maxDistance = maxScore;
        this.totalCoins = totalCoins;
    }

    public void SaveScore()
    {
        string path = GetPersistentPath();

        if (!string.IsNullOrEmpty(path))
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(path, json);
        }
        else
        {
            Debug.LogError("Could not get the persistent path for saving Score.");
        }
    }
    public static Score LoadScore()
    {
        string path = GetPersistentPath();

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<Score>(json);
        }
        else
        {
            return null;
        }
    }

    private static string GetPersistentPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Path.Combine(Application.persistentDataPath, "Score.json");
#else
        return Path.Combine(Application.dataPath, "Score.json");
#endif
    }
}
