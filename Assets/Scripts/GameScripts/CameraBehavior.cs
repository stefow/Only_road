using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public List<Transform> camPos;
    public float camSpeed;
    public float rotationSpeed;

    private int clickLayerMask;
    void Start()
    {
        clickLayerMask = LayerMask.GetMask("Click");
    }

    void Update()
    {
        cameraTransition();
    }
    int camIndex = 0;
    private void cameraTransition()
    {
        if ((camIndex < camPos.Count-1) && transform.position == camPos[camIndex].transform.position) 
        {
            camIndex++;
        }
        FollowPosition(camPos[camIndex]);
    }
    private void FollowPosition(Transform cp)
    {
        transform.position = Vector3.MoveTowards(transform.position, cp.position, camSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, cp.rotation, rotationSpeed * Time.deltaTime);
    }
}
