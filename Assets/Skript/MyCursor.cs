using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour
{
    public Texture2D cursorSpiel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorSpiel, Vector2.zero, CursorMode.ForceSoftware);
    }
}
