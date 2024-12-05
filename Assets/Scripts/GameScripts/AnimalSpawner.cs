using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public List<GameObject> animals;
    void Start()
    {
        ShopData shopData = ShopData.LoadShopData();
        if (shopData != null)
        {
            GameObject instantiatedObject = Instantiate(animals[shopData.equippedIndex], transform.position, Quaternion.identity);
            instantiatedObject.transform.Rotate(0f, -90f, 0f);
            instantiatedObject.transform.position += new Vector3(0, 0.2f, 0);
            instantiatedObject.transform.SetParent(transform);
        }
        else
        {
            GameObject instantiatedObject = Instantiate(animals[0], transform.position, Quaternion.identity);
            instantiatedObject.transform.Rotate(0f, -90f, 0f);
            instantiatedObject.transform.position += new Vector3(0, 0.2f, 0);
            instantiatedObject.transform.SetParent(transform);
        }
        
    }
}
