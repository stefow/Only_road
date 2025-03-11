using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderBehavior : MonoBehaviour
{
    [SerializeField] float snapInterval;
    [SerializeField] float minY = -6;
    [SerializeField] float maxY = 2;

    private bool isDragging = false;
    private Vector3 offset;
    private float clampedY = 0;
    private float snappedY = 0;
    private Vector3 mousePosition;
    private void OnEnable()
    {
        int random = Random.Range(-1, 2);
        transform.position = new Vector3(transform.position.x, random * 2,transform.position.z);
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.layer= 8;
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }
    }
    void OnMouseUp()
    {
        if (isDragging)
        {
            clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
            snappedY = Mathf.Round(clampedY / snapInterval) * snapInterval;
            transform.position = new Vector3(transform.position.x, snappedY, transform.position.z);
            this.gameObject.layer = 6;
        }
        isDragging = false;
    }
    void OnMouseDrag()
    {
        if (isDragging)
        {
            mousePosition = GetMouseWorldPosition();
            clampedY = Mathf.Clamp(mousePosition.y + offset.y, minY, maxY);
            transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        }
    }
    Vector3 GetMouseWorldPosition()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
