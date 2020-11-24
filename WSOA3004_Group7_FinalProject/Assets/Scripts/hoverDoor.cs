using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverDoor : MonoBehaviour
{
    public Texture2D cursor;
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        GameManagerScript.instance.hovering = true;
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameManagerScript.instance.hovering = false;
    }
}
