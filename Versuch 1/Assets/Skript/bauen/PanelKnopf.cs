using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RawImage))]
public class PanelKnopf : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int gebaeudeNummer;//0 nichts; 10,11,12 haus; 20,21,22 weide; 30,31,32 feld; ...1 klein;...2 mittel;...3 groß
    public GameObject gebaeude;

    public KnopfGruppe knopfGruppe;
    public RawImage hintergrund;

    public static GameObject gebautetsGebaeude;

    // Start is called before the first frame update
    void Start()
    {
        hintergrund = GetComponent<RawImage>();
        knopfGruppe.Subscribe(this);
    }
    //Methode beim erzeugen eines Gebaeudes
    public void KnopfGedrueckt()
    {
        Testing.objektGebaut = gebaeudeNummer;
        gebautetsGebaeude= Instantiate(gebaeude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        knopfGruppe.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        knopfGruppe.OnTabEnter(this);
        if (gebaeudeNummer != 0)
        {
            KameraKontroller.aktiviert = false;
            KnopfGedrueckt();            
        }
        else
        {
           if(gebautetsGebaeude!= null)
            {
                Testing.objektGebaut = 0;
                Destroy(gebautetsGebaeude.GetComponent<ObjektBewegung>());
                Destroy(gebautetsGebaeude);
                gebautetsGebaeude = null; 
                KameraKontroller.aktiviert = true;
            }
        }            
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        knopfGruppe.OnTabExit(this);
    }
}
