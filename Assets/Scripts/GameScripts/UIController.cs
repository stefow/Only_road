using System.Collections;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public ButtonFunctions buttonFunctions;
    //Canvases
    public GameObject ActiveGamePanel;
    public GameObject LoadingPanel;
    public GameObject SettingsPanel;
    public GameObject EndPanel;

    //ActiveGamePanel
    public TMP_Text DistanceText;
    public TMP_Text BestDistanceText;
    public TMP_Text CoinsCollectedText;

    //End panel
    public TMP_Text FinishedDistanceText;
    public TMP_Text FinishedCoinsCollectedText;
    public TMP_Text FinishedTotalCoinsText;

    public TMP_Text CountDownText;
    LevelMainBehavior LevelMainBehavior;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        LoadingPanel.SetActive(true);
        LevelMainBehavior = LevelMainBehavior.Instance;
    }
    public void UpdateDistance(float distance)
    {
        DistanceText.text = distance.ToString("00000");
    }
    public void UpdateBestDistance(float distance)
    {
        BestDistanceText.text = distance.ToString();
    }
    public void UpdateCurrentCoins(int coins)
    {
        CoinsCollectedText.text = coins.ToString("0000");
    }
    public void ActiveGame()
    {
        LoadingPanel.SetActive(false);
        ActiveGamePanel.SetActive(true);
        EndPanel.SetActive(false);
        StartCoroutine(CountDown(CountDownText));
    }
    public void Finished()
    {
        LoadingPanel.SetActive(false);
        ActiveGamePanel.SetActive(false);
        buttonFunctions.SlideDownPanel(EndPanel.GetComponent<RectTransform>());
    }
    public void UpdateFinishPanel(int distance,int CoinsCollected,int TotalCoinsOwned)
    {
        FinishedDistanceText.text = distance.ToString()+" m";
        FinishedCoinsCollectedText.text = CoinsCollected.ToString();
        FinishedTotalCoinsText.text = TotalCoinsOwned.ToString();
    }
    private IEnumerator CountDown(TMP_Text text)
    {
        for (int i = 3; i >0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(0.6f);
        }
        text.text = "Go!";
        LevelMainBehavior.GameStarted = true;
        yield return new WaitForSeconds(1);
        text.text ="";
    }
}
