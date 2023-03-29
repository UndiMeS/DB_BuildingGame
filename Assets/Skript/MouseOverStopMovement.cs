using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MouseOverStopMovement : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
{
    public bool StopMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnMouseOver()
    //  {
    //      StopMovement = true;
    //  }

    //  void OnMouseExit()
    //  {
    //      StopMovement = false;
    //  }

     public void OnPointerEnter(PointerEventData eventData)
     {
         StopMovement = true;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         StopMovement = false;
     }
}
