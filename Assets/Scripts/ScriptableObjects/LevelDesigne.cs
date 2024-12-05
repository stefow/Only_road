using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level beh", menuName = "LevelDesigne", order = 1)]
public class LevelDesigne : ScriptableObject
{
    public List<biomes> list;
}
[System.Serializable]
public class biomes
{
    public string BiomeName;
    public GameObject Floor;
    public List <slider> sliders;
    public int duration;

    biomes(string biomeName, List<slider> sliders, int duration)
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