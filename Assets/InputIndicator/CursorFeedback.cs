using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CursorFeedback : MonoBehaviour
{
    [SerializeField]
    private GameObject feedback;

    [SerializeField]
    private GameObject cursor;

    [SerializeField]
    private GameObject circle;

    [SerializeField]
    private float fadeInTimeCursor = 0.3f; // Durée Fade In CURSEUR
    
    [SerializeField]
    private float fadeInTimeCircle = 0.3f; // Durée Fade In CERCLE

    [SerializeField]
    private float fadeOutTimeCursor = 0.2f; // Durée Fade Out CURSEUR

    [SerializeField]
    private float fadeOutTimeCircle = 0.2f; // Durée Fade Out CERCLE

    [SerializeField]
    private float tailleMaxVoulueCursor = 1.5f;
    
    [SerializeField]
    private float tailleMaxVoulueCircle = 1.5f;



    private void Start()
    {
        cursor = GetComponent<Image>().gameObject;
        circle = GetComponent<Image>().gameObject;
        circle.transform.localScale = Vector3.zero;
        cursor.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            feedback.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            CursorFade();
            CircleFade();
        }
    }

    
    private void CursorFade()
    {
        
        cursor.transform.DOScale(Vector3.one * tailleMaxVoulueCursor, fadeInTimeCursor).SetEase(Ease.OutQuint)
            .OnComplete(() => cursor.transform.DOScale(Vector3.zero, fadeOutTimeCursor)).SetEase(Ease.OutQuint);
    }
    
    private void CircleFade()
    {
        
        circle.transform.DOScale(Vector3.one * tailleMaxVoulueCircle, fadeInTimeCircle).SetEase(Ease.OutQuint)
            .OnComplete(() => circle.transform.DOScale(Vector3.zero, fadeOutTimeCircle)).SetEase(Ease.OutQuint);
    }


}
