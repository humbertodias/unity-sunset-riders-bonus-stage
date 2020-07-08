using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHit : MonoBehaviour
{
    public Texture2D cursorOverTexture;
    public Texture2D cursorDownTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorDownTexture, Vector2.zero, cursorMode);
        }
    }
    
    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
        Cursor.SetCursor(cursorOverTexture, hotSpot, cursorMode);
    }
    
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Cursor.SetCursor(cursorDownTexture, Vector2.zero, cursorMode);
    }
    
}
