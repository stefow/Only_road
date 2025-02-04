using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    [SerializeField] LevelDesigne levelDesign;
    [SerializeField] float speed = 5;
    [SerializeField] bool start = false;
    [SerializeField] float floorNextSpawn = 30;
    [SerializeField] float speedUpDistance = 40;
    [SerializeField] GameObject pointer;
    
    bool firstTry=true;
    bool spawned = false;
    float spawnNextPos = 0;
    int prevSlider = -1;
    void Start()
    {
        spawnNextPos =transform.position.x;
        
    }
    void Update()
    {
        if (start)
        {   if(transform.position.x< speedUpDistance)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (transform.position.x >= spawnNextPos) spawned = false;
            if (!spawned)
            {
                spawn();
                if(transform.position.x>floorNextSpawn)
                {
                    SpawnFloor(currentBiome);
                }
            }
        }
        
    }
    private void SpawnRandomSlider(int biome)
    {
        int numberOfSliders =levelDesign.list[biome].sliders.Count-1;
        int randomSliderIndex= Random.Range(0, numberOfSliders+1);
        prevSlider=randomSliderIndex;
        spawnNextPos += levelDesign.list[biome].sliders[randomSliderIndex].width;
        Instantiate(levelDesign.list[biome].sliders[randomSliderIndex].sliderObject,new Vector3(spawnNextPos,0,transform.position.z),Quaternion.identity);
        spawnNextPos += levelDesign.list[biome].sliders[randomSliderIndex].width+1f;
        if (SliderCount<2 && firstTry&& randomSliderIndex!=11&&biome==0) { Instantiate(pointer, new Vector3(spawnNextPos-2f, 1, transform.position.z-1.5f), Quaternion.identity); }
        spawned = true;
    }
    private void SpawnFloor(int biome)
    {
        Instantiate(levelDesign.list[biome].Floor, new Vector3(floorNextSpawn+50, -2.35f, 13.25f), Quaternion.identity);
        floorNextSpawn += 50;
    }
    int SliderCount= 0;
    int currentBiome=0;
    private void spawn()
    {
        if (SliderCount >= levelDesign.list[currentBiome].duration)
        {
            if(currentBiome<levelDesign.list.Count-1)
            {
                SliderCount = 0;
                currentBiome++;
            }
            else
            {
                SliderCount = 0;
            }
        }
        SpawnRandomSlider(currentBiome);
        SliderCount++;
    }
}
