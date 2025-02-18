using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Biome", order = 2)]
public class Biome : ScriptableObject
{
    public string Name;
    public Material Skybox;
    public GameObject Floor;
    public float FloorWidth;
    public int Duration;
    public List<Slider> Sliders;
    public Slider GetRandomSlider()
    {
        int random = UnityEngine.Random.Range(0, TotalChance());
        int currentChance=0;
        foreach (Slider slider in Sliders) {
            currentChance += slider.SpawnChance;
            if (random < currentChance) return slider;
        }
        return Sliders[0];
    }
    private int TotalChance()
    {
        int sum = 0;
        foreach (Slider slider in Sliders)
        {
            sum += slider.SpawnChance;
        }
        return sum;
    }
    Biome(string biomeName, List<Slider> sliders, int duration)
    {
        Name = biomeName;
        this.Sliders = sliders;
        this.Duration = duration;
    }
}
[Serializable]
public class Slider
{
    public GameObject prefab;
    public int SpawnChance;
    public float Width;
}