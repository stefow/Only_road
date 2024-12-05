using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SliderSpecialSpawns : MonoBehaviour
{
    [SerializeField] List<Transform> spawns;
    [SerializeField] Spawnables spawnables;

    void Start()
    {
        foreach(Transform t in spawns)
        {
            foreach(spawnItem si in spawnables.spawnItems)
            {
                if (Random.Range(0, 1000) <= si.probabitly)
                {
                    var pitem= Instantiate(si.itemObject, t.position, Quaternion.identity);
                    pitem.transform.parent = t;
                }
            }
        }
    }
}
