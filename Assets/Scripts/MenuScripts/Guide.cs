using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public float speed = 1f;
    public float amplitude = 1f;
    public float offset = 0f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float time = Time.time + offset;
        float yPos = initialPosition.y + Mathf.Sin(time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
