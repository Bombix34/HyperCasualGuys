using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFeedback : MonoBehaviour
{
  

    [SerializeField]
    private GameObject Cursor;

    private Vector2 MousePosPlan;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosPlan.x = Input.mousePosition.x;
            MousePosPlan.y = Input.mousePosition.y;
            GameObject newCursor = Instantiate(Cursor, MousePosPlan, transform.rotation) as GameObject;
            newCursor.transform.SetParent(GameObject.FindGameObjectWithTag("Parent").transform, false);
        }
    }

}
