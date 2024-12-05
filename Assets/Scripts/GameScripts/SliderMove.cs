using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderMove : MonoBehaviour
{
    float minY=-6;
    float maxY=2;
    public float snapInterval;
    private AudioSource sound;
    public bool isDragging = false;
    private Vector3 offset;
    private ButtonFunctions buttonFunctions;
    private Collider collider;
    private void Start()
    {
        buttonFunctions= EventSystem.current.GetComponent<ButtonFunctions>();
        sound = GetComponent<AudioSource>();
        sound.volume = 0.2f;
        collider = GetComponent<Collider>();
        int random = Random.Range(-1, 2);
        transform.position = new Vector3(transform.position.x, random * 2,transform.position.z);
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collider.isTrigger = false;
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
            float snappedY = Mathf.Round(clampedY / snapInterval) * snapInterval;
            transform.position = new Vector3(transform.position.x, snappedY, transform.position.z);
            collider.isTrigger = true;
            if (buttonFunctions.SoundEnabled)sound.Play();   
        }

        isDragging = false;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            float clampedY = Mathf.Clamp(mousePosition.y + offset.y, minY, maxY);
            transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        }
    }


    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
