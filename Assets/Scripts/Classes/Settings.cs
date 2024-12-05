using System;
using System.IO;
using UnityEngine;

[Serializable]
public class Settings
{
    public bool soundEnabled;
    public bool musicEnabled;
    public Settings()
    {
        soundEnabled = true;
        musicEnabled = true;
    }
    public Settings(bool soundEnabled, bool musicEnabled)
    {
        this.soundEnabled = soundEnabled;
        this.musicEnabled = musicEnabled;
    }
    public void SaveSettings()
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
    public static Settings LoadSettings()
    {
        string path = GetPersistentPath();

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<Settings>(json);
        }
        else
        {
            return new Settings();
        }
    }

    // Get the persistent path for saving and loading the settings
    private static string GetPersistentPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Path.Combine(Application.persistentDataPath, "Settings.json");
#else
        return Path.Combine(Application.dataPath, "Settings.json");
#endif
    }
}
