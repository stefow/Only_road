using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class ShopItem:MonoBehaviour
{
    public int itemId;
    public Button buyButton;
    public TextMeshProUGUI buyButtonText;
    public TextMeshProUGUI priceText;
    public GameObject equippedPicture;
    public GameObject coinPicture;
    public int itemCost=200;

    //odredjuje stanje itema
    // 0 - nije kupljen
    // 1 - kupljen ali nije odabran
    // 2 - kupljen i odabran
    public int id=0;

    private Shop shop;
    private void Awake()
    {
        shop = this.GetComponentInParent<Shop>();
    }
    public void BuyOrEquip()
    {
        if(id==1)
        {
            buyButtonText.text = "Equipped";
            if(shop.equipped!=null) 
            { 
                shop.equipped.id = 1; 
                shop.equipped.UpdateItem();
                shop.equipped = this.gameObject.GetComponent<ShopItem>();
            }
            shop.saveData();
            id++;
            UpdateItem();
        }
        else if(id == 0)
        {
            if(shop.coinsOwned>=itemCost)
            {
                shop.coinsOwned-=itemCost;
                buyButtonText.text = "Equipp";
                priceText.text = "Owned";
                shop.UpdateCoinsText();
                coinPicture.SetActive(false);
                id++;
                shop.score.totalCoins=shop.coinsOwned;
                shop.UpdateAllShopItems();
                shop.saveData();
                shop.SaveCoins();
            }
        }
    }
    public void UpdateItem()
    {
        
        if (id == 0)
        {
            priceText.text = itemCost.ToString();
            coinPicture.SetActive(true);
            if(shop.coinsOwned< itemCost) 
            {
                buyButton.enabled = false;
            }
            equippedPicture.SetActive(false);
        }
        else if (id == 1)
        {
            buyButtonText.text = "Equip";
            priceText.text = "Owned";
            coinPicture.SetActive(false);
            buyButton.enabled = true;
            equippedPicture.SetActive(false);
        }
        else if(id==2)
        {
            shop.saveData();
            buyButtonText.text = "Equipped";
            priceText.text = "Owned";
            coinPicture.SetActive(false);
            shop.equipped = this.gameObject.GetComponent<ShopItem>();
            equippedPicture.SetActive(true);
        }
        
    }

}
