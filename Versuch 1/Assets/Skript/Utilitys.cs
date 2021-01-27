using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Utilitys 
{
    public const int sortingOrderDefault = 5000;

    // Create Text in the World
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    // Create Text in the World
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    //Gibt position der Maus in der Welt aus, mittels Ray
    public static Vector3 GetMouseWorldPosition(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        float hit;

        if (plane.Raycast(ray, out hit))
        {
           return ray.GetPoint(hit);  
        }
        return new Vector3(-1,-1,-1) ;
    }
    //verändert Text in TMP
    public static void TextInTMP(GameObject textfeld, string text)
    {
        textfeld.GetComponent<TextMeshProUGUI>().SetText(text);
    }

    public static bool ImBildschirm()
    {
        return Input.mousePosition.y > 280 * Screen.height / 900 ;
    }
}
