using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhneSchwacheEntity : MonoBehaviour
{
    public static bool schwachAus = true;
    public ERAufgabe eRAufgabe;
    public ERAufgabenText eRAufgabenText;
    public GameObject schwacheEMButton;
    public GameObject KonventionMitSchwach;
    public GameObject KonventionOhneSchwach;

    public List<GameObject> hilfen;

    void Start()
    {
        if (schwachAus)
        {
            eRAufgabe.wohncontainer_astronaut_Eig[2] = "0";
            eRAufgabe.stallcontainer_nutztier_Eig[2] = "0";
            eRAufgabe.forschungsstation_forschungsprojekt_Eig[2]="0";
            eRAufgabe.listeSchwacheEntity = new bool[]{ false, false, false, false, false, false, false, false };

            eRAufgabenText.aufgabe[1]= "Die Astronauten können nur dann eingeflogen werden. Astronauten wohnen in Wohncontainern (Beziehung 'wohnt'). Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (Kardinaliät n:1). Alle Astronauten haben einen Namen und ein Geburtstag, worüber man sie eindeutig bestimmen kann. Für die Anreise fallen bestimmte Anreisegebühren an und jeder hat eine bestimmte Aufgabe in der Siedlung (Weideastronaut (Symbol Mistgabel), Forschungsastronaut (Symbol Reagenzglas) und Feldastronaut (Symbol Weizenähre)).";

            schwacheEMButton.SetActive(false);

            foreach(GameObject hilfe in hilfen)
            {
                hilfe.SetActive(false);
            }

            KonventionMitSchwach.SetActive(true);
            KonventionOhneSchwach.SetActive(false);
        }
    }
}
