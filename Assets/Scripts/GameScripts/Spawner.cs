using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectsToSpawn;
    public List<GameObject> Spawn;
    public bool SpawnOnStart = false;
    void Start()
    {
        if(SpawnOnStart) SpawnStart();
        SpawnRandomSlider();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="ClickCollider")
        {
            SpawnRandomSlider();
        }
    }
    private void SpawnRandomSlider()
    {
        GameObject slider = Instantiate(ObjectsToSpawn,this.transform.position, Quaternion.identity);
        slider.AddComponent<Move>();
        slider.transform.Rotate(0,90,0);
    }
    private void SpawnFloor(int biome)
    {
        Instantiate(ObjectsToSpawn, new Vector3(50, -2.35f, 13.25f), Quaternion.identity).AddComponent<Move>();
    }
    private void SpawnStart()
    {
        Instantiate(Spawn[0], new Vector3(0, 0, 0), Quaternion.identity).AddComponent<Move>();
    }
}
