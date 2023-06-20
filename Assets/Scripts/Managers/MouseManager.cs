using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;

    public Texture2D point, attack, target, arrow;

    RaycastHit hitInfo;//use for saving the relevant information of the object hit by the ray; structure used to get information back from a raycast
    public event Action<Vector3> OnMouseClicked;//Register events through Action; type is event

    void Awake()
    {
        //Singleton mode
        if (Instance != null)
        {
            Destroy(gameObject);            
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        SetCursorTexture();
        MouseControl();
    }


    /// <summary>
    /// When the ray touches different things, there will be changes on the mouse cursor
    /// </summary>
    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))//check ray state and return according hitInfo
        {
            //switch mouse texture
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target, new Vector2(16,16), CursorMode.Auto);
                    break;

            }
        }
    }

    /// <summary>
    /// The ray collision point after connecting the ray from the camera and the mouse click point
    /// </summary>
    void MouseControl()
    {
        if(Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            //if (hitInfo.collider.gameObject.CompareTag("Ground"))
            //{
            //    OnMouseClicked?.Invoke(hitInfo.point); //Call this function, and all methods that register the OnMouseClicked event will be called
            //}


        }
    }
}
