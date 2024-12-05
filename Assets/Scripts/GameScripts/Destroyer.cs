using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] Transform Player;
    public float speed;
    public bool start=true;
    private void Update()
    {
        if (start)
        {
            Vector3 playerPos = new Vector3(Player.position.x+4, 0,0);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Destroyable")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag== "Destroyable")
        {
            Destroy(collision.gameObject);
        }
    }
}
