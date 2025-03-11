// Ignore Spelling: Biome

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Biome", order = 2)]
public class Biome : ScriptableObject
{
    public string Name;
    public Material SkyBox;
    public GameData Destroyer;
    public GameObject Floor;
    public Material FloorMaterial;
    public Color FloorTargetColor;
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
    public void RefreshColor()
    {
        Floor.GetComponent<Material>().color = FloorTargetColor;
    }
    public Biome(string biomeName, List<Slider> sliders, int duration)
    {
        Name = biomeName;
        this.Sliders = sliders;
        this.Duration = duration;
    }
    
    public IEnumerator TransitionMaterial(float duration)
    {
        Color startColor = FloorMaterial.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            FloorMaterial.color = Color.Lerp(startColor, FloorTargetColor, elapsedTime / duration);
            yield return null;
        }

        FloorMaterial.color = FloorTargetColor;
    }
    public IEnumerator ChangeSkyBox()
    {
        return null;
    }
}
[Serializable]
public class Slider
{
    public GameObject prefab;
    public int SpawnChance;
    public float Width;
}