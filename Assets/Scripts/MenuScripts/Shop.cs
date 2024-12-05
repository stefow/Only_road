using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public List<ShopItem> items;
    public TextMeshProUGUI coinsDisplay;
    public ShopItem equipped;
    public int coinsOwned=0;
    public Score score;
    public ShopData shopData;
    private void Start()
    {
        shopData = ShopData.LoadShopData();
        if(shopData == null )
        {
            shopData=new ShopData();
            foreach (ShopItem si in items)
            {
                shopData.data.Add(new Item(si.id, si.itemId));
            }
            shopData.SaveShopData();
        }
        else
        {
            int i = 0;
            foreach (ShopItem si in items)
            {
                si.id = shopData.data[i].id;
                si.itemId = shopData.data[i].itemId;
                i++;
            }
        }
        
        score = Score.LoadScore();
        if (score == null)
        {
            score = new Score();
            score.SaveScore();
        }
        coinsOwned=score.totalCoins;
        coinsDisplay.text = coinsOwned.ToString();
        UpdateAllShopItems();
    }
    public void UpdateCoinsText()
    {
        coinsDisplay.text = coinsOwned.ToString();
    }
    public void UpdateAllShopItems()
    {
        foreach (var item in items)
        {
            item.UpdateItem();
        }
        saveData();
    }
    public void saveData()
    {
        shopData.data.Clear();
        foreach (ShopItem si in items)
        {
            shopData.data.Add(new Item(si.id, si.itemId));
        }
        if(equipped!=null)
        {
            shopData.equippedIndex= equipped.itemId;
        }else { shopData.equippedIndex = 3; }
        shopData.SaveShopData();
    }
    public void SaveCoins()
    {
        score.totalCoins = coinsOwned;
        score.SaveScore();
    }
}
