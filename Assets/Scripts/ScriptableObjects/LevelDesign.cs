// Ignore Spelling: Biome Biomes

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelDesign", order = 1)]
public class LevelDesign : ScriptableObject
{
    public List<Biome> listOfBiomes;
    public GameObject GetFloor(int index)
    {
        return listOfBiomes[index].Floor;
    }
}