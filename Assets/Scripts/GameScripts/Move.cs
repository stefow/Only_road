using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {
        if(LevelMainBehavior.Instance.Move)
        {
            transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
        }
        
    }
}
