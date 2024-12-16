using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMainBehaviour : MonoBehaviour
{
    public bool start = false;
    public List<GameObject> Spawn;
    public GameObject Vehicle;
    public GameObject Animal;
    public Transform PlayerParent;
    public GameObject Player;
    //UI
    public Canvas MainCanvas;
    public Canvas LoadingCanvas;

    void Start()
    {
        //Spawning Objects
        int RandomSpawnIndex= Random.Range(0,Spawn.Count);
        Instantiate(Spawn[0], new Vector3(0,0,0), Quaternion.identity);
        GameObject vehicle= Instantiate(Vehicle, PlayerParent.position, Quaternion.Euler(new Vector3(0,-90,0)));
        GameObject animal= Instantiate(Animal, PlayerParent.position+new Vector3(0,0.165f,0), Quaternion.Euler(new Vector3(0, -90, 0)));
        vehicle.transform.SetParent(PlayerParent);
        animal.transform.SetParent(PlayerParent);
        //UI
        MainCanvas.enabled = true;
        LoadingCanvas.enabled = false;
        Player.SetActive(true);
    }
    void Update()
    {
        
    }
}
