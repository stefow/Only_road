using System.Collections;
using UnityEngine;

public class LevelMainBehavior : MonoBehaviour
{
    public static LevelMainBehavior Instance;
    private UIController uIController;
    private GameData gameData;
    public Destroyer destroyer;
    public ShopData shopData;
    public GameObject Cart;
    public GameObject Animal;
    public GameObject Player;

    public GameObject Cam;
    public bool Move = true;
    public float Speed = 2;
    public float SpeedIncrement = 0.2f;
    public float MaxSpeed=6;
    public bool GameStarted = false;

    public Material material;
    public Color color;

    private int coinsCollected;
    private float distance;
    private int bestDistance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        gameData = GameData.GetInstance();
        SpawnEquipped();
        coinsCollected=0; 
        distance=0;
        bestDistance = gameData.Distance;
    }
    public void Start()
    {
        //Application.targetFrameRate = 20;
        uIController = UIController.Instance;
        uIController.UpdateBestDistance(bestDistance);
    }
    public void AddCoins(int amount)
    {
        coinsCollected += amount;
        uIController.UpdateCurrentCoins(coinsCollected);
    }
    private void Update()
    {
        if (Move)
        {
            distance += Speed * Time.deltaTime;
        }
        destroyer.Chase(!Move);
        uIController.UpdateDistance(distance);
    }
    private void SpawnEquipped()
    {
        Cart = Instantiate(shopData.FindCartById(gameData.EquippedCart),
            Player.transform.position, Quaternion.Euler(new Vector3(0, -90, 0)));
        Animal = Instantiate(shopData.FindAnimalById(gameData.EquippedAnimal),
            Player.transform.position + new Vector3(0, 0.165f, 0), Quaternion.Euler(new Vector3(0, -90, 0)));

        Cart.transform.SetParent(Player.transform);
        Animal.transform.SetParent(Player.transform);
    }
    public void Failed()
    {
        Player.SetActive(false);
        Move = false;
        uIController.UpdateFinishPanel((int)distance, coinsCollected, coinsCollected + gameData.Coins);
        uIController.Finished();
        if (distance > gameData.Distance) gameData.Distance = (int)distance;
        gameData.Coins += coinsCollected;
        gameData.Save();
    }
    public void StartGame(bool state)
    {
        if (state) 
        {
            UIController.Instance.ActiveGame();
            StartCoroutine(SpeedUp());
        }
        else
        {
            GameStarted = false;
        }
        
    }
    public bool IsStared()
    {
        return GameStarted;
    }
    private IEnumerator SpeedUp()
    {
        while (Speed<MaxSpeed)
        {
            Speed += SpeedIncrement;
            yield return new WaitForSeconds(1);
        }
        
    }
    IEnumerable TransitToSkyBox()
    {
        yield return new WaitForSeconds(1);
    }
}
