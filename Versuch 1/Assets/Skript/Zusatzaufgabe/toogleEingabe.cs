using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;  

public class toogleEingabe : MonoBehaviour
{
    ToggleGroup toggleGroupInstance;

    //Gibt den Namen des ausgewählten Toogles aus mit currentSelection.name
    public Toggle currentSelection{
        get{return toggleGroupInstance.ActiveToggles ().FirstOrDefault ();}
    }
    
    void Start()
    {
        toggleGroupInstance =  GetComponent<ToggleGroup> ();
        Debug.Log ("ausgewählt"+ currentSelection.name);
        
        toggleOff();
    }
 //zurücksetzten aller Toggles
    public void toggleOff (){
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle> ();
        for (int i = 0; i < 4; i++){
            toggles [i].isOn = false;
        }
    }
}
