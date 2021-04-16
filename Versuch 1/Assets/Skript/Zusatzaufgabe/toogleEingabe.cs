using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;  

public class toogleEingabe : MonoBehaviour
{
    public ToggleGroup toggleGroupInstance;
    //Gibt den Namen des ausgewählten Toogles aus mit currentSelection.name
    public Toggle currentSelection{
        get{return toggleGroupInstance.ActiveToggles ().FirstOrDefault ();}
    }
    
    void Start()
    {
        toggleGroupInstance =  GetComponent<ToggleGroup> ();    
        toggleOff();
    }

    public void init()
    {
        toggleGroupInstance = GetComponent<ToggleGroup>();
        toggleOff();
    }
    
    //zurücksetzten aller Toggles
    public void toggleOff (){
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle> ();
        for (int i = 0; i < 4; i++){
            toggles [i].isOn = false;
        }
    }

    public void toggleColor (Color c, Toggle t){
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle> ();
        ColorBlock cb = t.colors;
        cb.normalColor = c;
        t.colors = cb;
    }
    public void toggleRed (){
        //Color c = new Color(192,57,43);
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle> ();
        for (int i = 0; i < 4; i++){
            
            ColorBlock cb = toggles [i].colors;
            cb.normalColor = new Color(0.753f, 0.224f, 0.169f);
            toggles [i].colors = cb;
        }
    }
    public void toggleWhite (){
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle> ();
        for (int i = 0; i < 4; i++){
            
            ColorBlock cb = toggles [i].colors;
            cb.normalColor = Color.white;
            toggles [i].colors = cb;
        }
    }
}