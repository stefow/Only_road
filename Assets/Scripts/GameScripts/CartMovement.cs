using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    //Physics
    public float speed = 5;
    public int maxDistance=0;
    public Transform ObstacleCheckPosition;
    public bool startMoving = true;
    private Rigidbody rb;

    //Front detection
    public float FrontDetectDistance=1.5f;
    public LayerMask IgnoredFrontHitLayers;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(IsWayClear())
        {
            Debug.DrawRay(ObstacleCheckPosition.position, new Vector3(2, 0, 0), Color.green);
            LevelMainBehavior.Instance.Move=true;
        }
        else 
        {
            Debug.DrawRay(ObstacleCheckPosition.position, new Vector3(2, 0, 0), Color.red);
            LevelMainBehavior.Instance.Move = false;
        }
    }
    private void MoveRb()
    {
        rb.velocity = Vector3.right * speed;
    }
    private bool IsGrounded()
    {
        bool grounded = Physics.Raycast(this.transform.position, Vector3.down, 1f, LayerMask.NameToLayer("Ground"));

        if(grounded)
        {
            Debug.DrawRay(this.transform.position, Vector3.down, Color.green);
        }
        else
        {
            Debug.DrawRay(this.transform.position, Vector3.down, Color.red);
        }
        return grounded;

    }
    
    private bool IsWayClear()
    {
        return !Physics.Raycast(ObstacleCheckPosition.position, Vector3.right, FrontDetectDistance, IgnoredFrontHitLayers); ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Fail")
        {
            LevelMainBehavior.Instance.Failed();
        }
        if (other.transform.tag == "ClickCollider")
        {
            Destroy(other);
        }
    }

}
