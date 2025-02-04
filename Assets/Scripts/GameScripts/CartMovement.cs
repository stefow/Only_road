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

    public bool startMoving = true;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (startMoving && IsGrounded())
        {
            maxDistance = (int)transform.position.x;
            MoveRb();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Fail")
        {
            LevelMainBehavior.Instance.Failed();
        }
    }

}
