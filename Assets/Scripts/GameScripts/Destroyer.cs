using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float Speed=2;
    public float RetreatSpeed=0.4f;
    public bool StartMoving=false;
    private Vector3 startPosition;
    private void Awake()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (StartMoving)
        {
            this.transform.position += Time.deltaTime * Vector3.right * Speed;
        }
        else if (this.transform.position.x > startPosition.x)
        {
            this.transform.position += Time.deltaTime * Vector3.left * RetreatSpeed;
        }
    }
    public void Chase(bool state)
    {
        StartMoving = state;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Slider")
        {
            StartCoroutine(Shake(other.gameObject));
        }
        if (other.transform.tag == "Click")
        {
            Destroy(other);
        }
    }
    
    private IEnumerator Shake(GameObject other)
    {
        int polar = -1;
        other.tag = "Indestructible";
        Vector3 ShakeAmount = new Vector3(0.1f, 0, 0.05f);
        for (int i = 0; i < 20; i++)
        {
            other.transform.localPosition += ShakeAmount* polar;
            polar *= -1;
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(Sink(other.gameObject));
    }
    private IEnumerator Sink(GameObject other)
    {
        while (other.transform.position.y>-15)
        {
            other.transform.position += Vector3.down * Time.deltaTime * 3;
            yield return null;
        }
        Destroy(other);
    }
}
