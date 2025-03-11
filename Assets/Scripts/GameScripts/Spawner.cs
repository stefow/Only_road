using System.Collections;
using UnityEngine;

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
    float sliderWidth = 0;
    float floorWidth = 0;
    private Vector3 offset = Vector3.zero;
    void Start()
    {
        SpawnStart();
        SpawnSlider();
        SpawnFloor();
        StartCoroutine(GoToInitialPosition());
        StartCoroutine(levelDesign.listOfBiomes[biomeIndex].TransitionMaterial(0));
        
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
                //RenderSettings.skybox = levelDesign.listOfBiomes[biomeIndex].SkyBox;
                StartCoroutine(levelDesign.listOfBiomes[biomeIndex].TransitionMaterial(5));
            }
        }
        return levelDesign.listOfBiomes[biomeIndex].GetRandomSlider();
    }
    private void Update()
    {
        if (Mathf.Abs(CurrentSlider.transform.position.x - this.transform.position.x) >= sliderWidth)
        {
            SpawnSlider();
        }
        if (Mathf.Abs(CurrentFloor.transform.position.x - this.transform.position.x) >= floorWidth)
        {
            SpawnFloor();
        }
    }

    private void SpawnSlider()
    {
        Slider slider = GetNextSlider();
        if (CurrentSlider == null) 
            CurrentSlider = Instantiate(slider.prefab, this.transform.position, Quaternion.identity);
        else
           CurrentSlider = Instantiate(slider.prefab, CurrentSlider.transform.position + offset, Quaternion.identity);
        sliderWidth = slider.Width;
        CurrentSlider.AddComponent<Move>();
        CurrentSlider.transform.Rotate(0,90,0);
        offset.x = sliderWidth;
    }
    private void SpawnFloor()
    {
        CurrentFloor = Instantiate(levelDesign.GetFloor(biomeIndex), transform.position, Quaternion.identity);
        floorWidth = levelDesign.listOfBiomes[biomeIndex].FloorWidth;
        CurrentFloor.AddComponent<Move>();
    }
    private void SpawnStart()
    {
        Instantiate(Spawn, new Vector3(0, 0, 0),Quaternion.identity).AddComponent<Move>();
    }
    private IEnumerator GoToInitialPosition()
    {
        yield return new WaitForSeconds(0.5f);
        while (this.transform.position.x < DesiredSpawnPosition.position.x)
        {
            this.transform.position += Vector3.right*Time.deltaTime*30;
            yield return null;
        } 
        LevelMainBehavior.Instance.StartGame(true);
        
    }
}
