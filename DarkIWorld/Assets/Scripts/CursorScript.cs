using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public GameObject Cursor_;
    public CursorMode cursorMode = CursorMode.Auto;

    public Vector2 hotSpot;
    public Camera cam;

    

    private void Update()
    {
        hotSpot = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Cursor.visible == true)
        {
            Cursor_.SetActive(false);
        }
        else
        {
            Cursor_.SetActive(true);
        }
    }

    private void FixedUpdate()
    {


        Cursor_.transform.position = hotSpot;
    }
    


}
