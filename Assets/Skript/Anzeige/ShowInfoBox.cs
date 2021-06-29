using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoBox : MonoBehaviour
{
    public GameObject infoboxER;
    public GameObject infoboxSpiel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfobox();

    }

    public void ShowInfobox()
    {
        if(FehlerAnzeige.fehlertext.Equals("") && FehlerAnzeige.tutorialtext_ER.Equals("")){
            infoboxER.SetActive(false);
        }else{
            infoboxER.SetActive(true);
        }
        if(FehlerAnzeige.fehlertext.Equals("") && FehlerAnzeige.tutorialtext_Spiel.Equals("")){
            infoboxSpiel.SetActive(false);
        }else{
            infoboxSpiel.SetActive(true);
        }
    }
}
