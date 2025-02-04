using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMainBehavior : MonoBehaviour
{
    public static LevelMainBehavior Instance;

    public ShopData shopData;
    //Canvases
    public GameObject ActiveGamePanel;
    public GameObject LoadingPanel;
    public GameObject SettingsPanel;
    public GameObject EndPanel;

    public TMP_Text CoinsCollectedText;
    public TMP_Text DistanceText;
    public TMP_Text BestDistanceText;

    public TMP_Text FinishedDistanceText;
    public TMP_Text FinishedCoinsCollectedText;
    public TMP_Text FinishedCoinsSavedText;

    public bool start = false;
    public List<GameObject> Spawn;
    public GameObject Cart;
    public GameObject Animal;
    public GameObject Player;

    public GameObject Cam;

    private int CoinsCollected;
    private int Distance;
    private int BestDistance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            
        }
        SpawnEquipped();
        CoinsCollected=0; Distance=0;
        BestDistance = GameData.GetInstance().Distance;

    }
    void Start()
    {
        SetUI();
    }

    void Update()
    {
        UpdateUI();
    }
    public void addCoins(int amount)
    {
        CoinsCollected += amount;
    }
    private void UpdateUI()
    {
        CoinsCollectedText.text = CoinsCollected.ToString();
        DistanceText.text = Distance.ToString();
        BestDistanceText.text = BestDistance.ToString();
    }
    private void SetUI()
    {
        Player.SetActive(true);
        ActiveGamePanel.SetActive(true);
        LoadingPanel.SetActive(false);
    }
    private void SpawnEquipped()
    {
        Instantiate(Spawn[0], new Vector3(0, 0, 0), Quaternion.identity);

        Cart = Instantiate(shopData.FindCartById(GameData.GetInstance().EquippedCart),
            Player.transform.position, Quaternion.Euler(new Vector3(0, -90, 0)));
        Animal = Instantiate(shopData.FindAnimalById(GameData.GetInstance().EquippedAnimal),
            Player.transform.position + new Vector3(0, 0.165f, 0), Quaternion.Euler(new Vector3(0, -90, 0)));

        Cart.transform.SetParent(Player.transform);
        Animal.transform.SetParent(Player.transform);
    }
    public void Failed()
    {
        Player.SetActive(false);
        ActiveGamePanel.SetActive(false);
        EndPanel.SetActive(true);
        SaveProgress();
    }
    public void SaveProgress()
    {

    }
}
