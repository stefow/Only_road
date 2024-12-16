using UnityEngine;
public class Shop : MonoBehaviour
{
    public ShopData ShopData;
    public GameObject UIParent;
    public void Start()
    {
        foreach(Animal animal in ShopData.Animals)
        {
            GameObject prefab= Instantiate(ShopData.UIPrefab,UIParent.transform);
            animal.UpdateUIElement(prefab);
        }
    }

}