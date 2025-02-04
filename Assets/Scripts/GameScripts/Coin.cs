using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            LevelMainBehavior.Instance.addCoins(value);
            Destroy(this.gameObject);
        }
    }
}
