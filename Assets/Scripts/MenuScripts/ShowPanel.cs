using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public RectTransform panel;
    public float speed = 5f;

    private Vector2 targetPosition;
    private Vector2 originalPosition;
    private void Start()
    {
        originalPosition = panel.anchoredPosition;
        
    }
    private void OnEnable()
    {
        targetPosition = new Vector2(originalPosition.x, 0f);
    }
    private void Update()
    {
        panel.anchoredPosition = Vector2.Lerp(panel.anchoredPosition, targetPosition, speed * Time.deltaTime);
    }
    public void MoveUpAndHide()
    {
        panel.anchoredPosition = new Vector2(originalPosition.x, 413f);
        gameObject.SetActive(false);
    }
}
