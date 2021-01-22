using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorFeedback : MonoBehaviour
{


    [SerializeField]
    private GameObject Cursor;

    [SerializeField]
    private float fadeDelay = 10f;
    private float alphaValue = 0;
    private bool destroyGameObject = false;


    private Vector2 MousePosPlan;

   

   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (destroyGameObject == false)
            {
                MousePosPlan.x = Input.mousePosition.x;
                MousePosPlan.y = Input.mousePosition.y;
                GameObject newCursor = Instantiate(Cursor, MousePosPlan, transform.rotation) as GameObject;
                newCursor.transform.SetParent(GameObject.FindGameObjectWithTag("Parent").transform, false);
                newCursor.transform.position = MousePosPlan;
                destroyGameObject = true;
            }
            else if(destroyGameObject == true)
            {
                DestroyCursor();
            }
            

            

            



        }
    }
    private void DestroyCursor()
    {
        Destroy(this.gameObject, 2);
    }
    


}
