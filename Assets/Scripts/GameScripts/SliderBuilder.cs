// Ignore Spelling: Spawnable
using System.Collections.Generic;
using UnityEngine;

public class SliderBuilder : MonoBehaviour
{
    public GameObject[] BlockedParts;
    public GameObject[] ClearedParts;
    public GameObject Foundation;
    public GameObject Platform;
    public SpawnableItems SpawnableItems;
    public float SpawnableItemsChance;

    private int MaxSliderHeight = 3;
    private List<GameObject> ChosenParts;
    private void Awake()
    {
        ChosenParts = new List<GameObject>();
        BuildSlider();
    }
    private void BuildSlider()
    {
        int height = Random.Range(2, MaxSliderHeight+1);
        int cleared = Random.Range(0, height);
        for (int i = 0; i < height; i++)
        {
            if (i == cleared)
            {
                ChosenParts.Add(ClearedParts[Random.Range(0, ClearedParts.Length)]);
            }
            else
            {
                ChosenParts.Add(BlockedParts[Random.Range(0, BlockedParts.Length)]);
            }
        }
        int j = 0;
        foreach(GameObject part in ChosenParts)
        {
            Instantiate(part, this.transform.position + new Vector3(0, j * 2, 0), Quaternion.identity, this.gameObject.transform);
            Instantiate(Platform, this.transform.position + new Vector3(0, j * 2, 0), Quaternion.identity, this.gameObject.transform);
            if(Random.Range(0, 101)<=SpawnableItemsChance)
                Instantiate(SpawnableItems.GetRandomItem().Prefab, this.transform.position + new Vector3(0, j * 2, 0), Quaternion.identity, this.gameObject.transform);
            j++;
        }
    }
}
