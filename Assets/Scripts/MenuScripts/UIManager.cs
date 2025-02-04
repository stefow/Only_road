using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameData gameData;

    private void Awake()
    {
        gameData = GameData.GetInstance();        
    }

}
