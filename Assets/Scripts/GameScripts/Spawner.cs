using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    public string SliderTag;
    public string FloorTag;
    public LevelDesign levelDesign;
    public GameObject Spawn;
    public Transform DesiredSpawnPosition;

    private int biomeIndex = 0;
    private int sliderCounter = 0;
    private GameObject CurrentSlider;
    private GameObject CurrentFloor;
    float sliderOffset = 0;
    float floorOffset = 0;
    void Start()
    {
        CurrentSlider = this.gameObject;
        CurrentFloor = this.gameObject;
        SpawnStart();
        StartCoroutine(GoToInitialPosition());
    }
    private Slider GetNextSlider()
    {
        if (sliderCounter < levelDesign.listOfBiomes[biomeIndex].Duration)
        {
            sliderCounter++;
            
        }
        else
        {
            sliderCounter = 0;
            if (levelDesign.listOfBiomes.Count > biomeIndex + 1)
            {
                biomeIndex++;
                RenderSettings.skybox = levelDesign.listOfBiomes[biomeIndex].Skybox;
            }
        }
        return levelDesign.listOfBiomes[biomeIndex].GetRandomSlider();
    }
    private void Update()
    {
        if (Vector3.Distance(CurrentSlider.transform.position, this.transform.position)>= sliderOffset)
        {
            SpawnSlider();
        }
        if (Vector3.Distance(CurrentFloor.transform.position, this.transform.position) >= floorOffset)
        {
            SpawnFloor();
        }
    }

    private void SpawnSlider()
    {
        Slider slider = GetNextSlider();
        CurrentSlider = Instantiate(slider.prefab, transform.position, Quaternion.identity);
        sliderOffset = slider.Width;
        CurrentSlider.AddComponent<Move>();
        CurrentSlider.transform.Rotate(0,90,0);
    }
    private void SpawnFloor()
    {
        CurrentFloor = Instantiate(levelDesign.GetFloor(biomeIndex), transform.position, Quaternion.identity);
        floorOffset = levelDesign.listOfBiomes[biomeIndex].FloorWidth;
        CurrentFloor.AddComponent<Move>();
    }
    private void SpawnStart()
    {
        Instantiate(Spawn, new Vector3(0, 0, 0),Quaternion.identity).AddComponent<Move>();
    }
    private IEnumerator GoToInitialPosition()
    {
        while (this.transform.position.x < DesiredSpawnPosition.position.x)
        {
            this.transform.position += Vector3.right*Time.deltaTime*20;
            yield return null;
        } 
        LevelMainBehavior.Instance.StartGame(true);
        
    }
}
