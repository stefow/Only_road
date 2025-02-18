using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {
        if(LevelMainBehavior.Instance.Move && LevelMainBehavior.Instance.IsStared())
        {
            transform.position += new Vector3(-LevelMainBehavior.Instance.Speed, 0, 0) * Time.deltaTime;
        }
        
    }
}
