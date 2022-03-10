using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhneSchwacheEntity : MonoBehaviour
{
    public static bool schwachAus = false;
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

            eRAufgabenText.aufgabe[1] = "Die Astronauten können nur dann eingeflogen werden. Astronauten wohnen in Wohncontainern (Beziehung 'wohnt'). Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (Kardinaliät n:1). Alle Astronauten haben einen Namen und ein Geburtstag, worüber man sie eindeutig bestimmen kann. Für die Anreise fallen bestimmte Anreisegebühren an und jeder hat eine bestimmte Aufgabe in der Siedlung (Weideastronaut (Symbol Mistgabel), Forschungsastronaut (Symbol Reagenzglas) und Feldastronaut (Symbol Weizenähre)).";
            eRAufgabenText.aufgabe[4] = "Verbesserungen werden durch Forschungsprojekte erreicht. Attribute von Sphären und Containern können mehrfach erforscht und so mehrfach verbessert werden. Forschungsprojekte optimieren die Forschungsmerkmale immer für alle zukünftig gebauten Objekte. Ein Forschungsprojekt hat somit ein bestimmtes Forschungsmerkmal und eine Forschungsstufe. Darüber kann ein Forschungsprojekt eindeutig ermittelt werden. Jedes Forschungsprojekt erzielt einen Verbesserungsfaktor, benötigt eine bestimmte Arbeiterzahl und Projektkosten. Mehrere Astronauten können in einem Forschungsprojekt forschen, jedoch kann ein Astronaut nur an einem Projekt forschen. \n In einer Forschungsstation werden mehrere Forschungsprojekte organisiert. Ein Forschungsprojekt verbessert mehrere Wohncontainer. Zugleich können mehrere Projekte einen Wohncontainer verbessern.";
            eRAufgabenText.aufgabe[6] = "Eine weitere Möglichkeit Erträge zu erzielen sind Weidesphären. Doch bevor wir diese anlegen, werden zunächst Nutztiere und Stallcontainer benötigt. Ein Stallcontainer hat Baukosten, eine eindeutige Containernummer (CNr.), eine Gehegezahl und eine Anzahl der noch freien Gehege. Stallcontainer werden exakt wie Wohncontainer durch Forschungsprojekte verbessert. Mehrere Nutztiere wohnen in einem Stallcontainer. Diese haben Transportkosten, einen Namen und eine Art. Jedes Nutztier kann eindeutig über Name und Art identifiziert werden.";


            schwacheEMButton.SetActive(false);

            foreach(GameObject hilfe in hilfen)
            {
                hilfe.SetActive(false);
            }

            KonventionMitSchwach.SetActive(false);
            KonventionOhneSchwach.SetActive(true);
        }
       
    }
}
