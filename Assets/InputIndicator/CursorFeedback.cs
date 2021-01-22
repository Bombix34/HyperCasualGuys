using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CursorFeedback : MonoBehaviour
{
    private GameObject cursor;

    private Vector2 MousePosPlan;

    private void Start()
    {
        cursor = GetComponentInChildren<Image>().gameObject;
        cursor.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursor.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            cursor.transform.DOScale(Vector3.one * 1.5f, 0.3f)
                .OnComplete(()=> cursor.transform.DOScale(Vector3.zero,0.2f));
        }
    }


}
