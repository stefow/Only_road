using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "ShopData", menuName = "ShopData", order = 1)]
public class ShopData : ScriptableObject
{
    public GameObject UIPrefab;
    public List<Cart> Carts;
    public List<Animal> Animals;
    public List<PowerUp> PowerUps;
}

[Serializable]
public abstract class ShopItem
{
    public string name;
    public string id;
    public int price;
    public Sprite image;
    
    public void UpdateUIElement(GameObject obj)
    {
        ShopUIElement uiElement= obj.GetComponent<ShopUIElement>();
        uiElement.NameText.text = name;
        uiElement.Price.text = price.ToString();
        uiElement.Image.sprite = image;
    }
}
