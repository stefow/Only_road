using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level beh", menuName = "LevelDesigne", order = 1)]
public class LevelDesigne : ScriptableObject
{
    public List<Biomes> list;
}
[System.Serializable]
public class Biomes
{
    public string BiomeName;
    public GameObject Floor;
    public List <slider> sliders;
    public int duration;

    Biomes(string biomeName, List<slider> sliders, int duration)
    {
        BiomeName = biomeName;
        this.sliders = sliders;
        this.duration = duration;
    }
}
[System.Serializable]
public class slider
{
    public GameObject sliderObject;
    public float width;
    slider(GameObject sliderObject, float width)
    {
        this.sliderObject = sliderObject;
        this.width = width;
    }
}