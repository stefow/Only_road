using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public float raycastDistance = 1f;
    public float speed = 5;
    public Transform groundCheck1;
    public Transform groundCheck2;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public LayerMask obsticleMask;
    public bool start=true;
    public float gravity=2;
    public GameObject destroyer;
    public GameObject cam;
    public int maxDistance;
    public int coins = 0;

    //Sounds
    public AudioClip CoinSound;
    public AudioClip WaterSplash;

    //UI
    public TextMeshProUGUI coinDisplay;
    public TextMeshProUGUI Distance;
    public TextMeshProUGUI BestDistance;
    public TextMeshProUGUI FinishedDistance;
    public TextMeshProUGUI FinishedCoinsCollected;
    public TextMeshProUGUI FinishedCoinsSaved;
    public GameObject ActiveGamePanel;
    public GameObject Settings;
    public GameObject Finished;


    private bool isGrounded1;
    private bool isGrounded2;
    private AudioSource audioData;
    private Rigidbody rb;
    private Score score;
    private void Awake()
    {
        score = Score.LoadScore();
        if (score == null)
        {
            score = new Score();
            score.SaveScore();
        }
        maxDistance = (int)score.maxDistance;
        BestDistance.text= score.maxDistance.ToString();
        audioData = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        maxDistance = (int)transform.position.x;
        Distance.text = maxDistance.ToString("D5");
    }
    private void FixedUpdate()
    {
        if (start)
        {
            MovePlayer();
        }
    }
    private void MovePlayer()
    {
        isGrounded1 = Physics.CheckSphere(groundCheck1.position, groundDistance, groundMask);
        isGrounded2 = Physics.CheckSphere(groundCheck2.position, groundDistance, groundMask);
        if (isGrounded1||isGrounded2)
        {
            rb.velocity = Vector3.right * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name.Contains("Coin"))
        {
            audioData.PlayOneShot(CoinSound);
            coins++;
            coinDisplay.text=coins.ToString("D4");
            Destroy(other.gameObject);
        }
        if (other.transform.tag=="Fail")
        {
            SaveScore();
            audioData.PlayOneShot(WaterSplash);
            ActiveGamePanel.SetActive(false);
            Finished.SetActive(true);
            Finished.SetActive(true);
            destroyer.GetComponent<Destroyer>().start = false;
            start = false;


            Destroy(rb);
        }
        if (other.transform.tag == "Destroyable")
        {
            if (speed <= 9)
            {
                speed += 0.05f;
                destroyer.GetComponent<Destroyer>().speed+=0.05f;
            }
        }
        if (other.transform.tag == "ClickCollider")
        {
            other.GetComponent<SliderMove>().isDragging = false;
            Destroy(other);
        }
    }
    void SaveScore()
    {
        score.totalCoins += coins;
        if (score.maxDistance < maxDistance)
        {
            score.maxDistance = maxDistance;
        }
        FinishedDistance.text = maxDistance.ToString();
        FinishedCoinsCollected.text = coins.ToString();
        FinishedCoinsSaved.text = score.totalCoins.ToString();
        score.SaveScore();
    }
}
