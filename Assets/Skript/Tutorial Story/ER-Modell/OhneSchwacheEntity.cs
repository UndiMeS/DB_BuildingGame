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

            eRAufgabenText.aufgabe[1] = "Die Astronauten k�nnen nur dann eingeflogen werden. Astronauten wohnen in Wohncontainern (Beziehung 'wohnt'). Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (Kardinali�t n:1). Alle Astronauten haben einen Namen und ein Geburtstag, wor�ber man sie eindeutig bestimmen kann. F�r die Anreise fallen bestimmte Anreisegeb�hren an und jeder hat eine bestimmte Aufgabe in der Siedlung (Weideastronaut (Symbol Mistgabel), Forschungsastronaut (Symbol Reagenzglas) und Feldastronaut (Symbol Weizen�hre)).";
            eRAufgabenText.aufgabe[4] = "Verbesserungen werden durch Forschungsprojekte erreicht. Attribute von Sph�ren und Containern k�nnen mehrfach erforscht und so mehrfach verbessert werden. Forschungsprojekte optimieren die Forschungsmerkmale immer f�r alle zuk�nftig gebauten Objekte. Ein Forschungsprojekt hat somit ein bestimmtes Forschungsmerkmal und eine Forschungsstufe. Dar�ber kann ein Forschungsprojekt eindeutig ermittelt werden. Jedes Forschungsprojekt erzielt einen Verbesserungsfaktor, ben�tigt eine bestimmte Arbeiterzahl und Projektkosten. Mehrere Astronauten k�nnen in einem Forschungsprojekt forschen, jedoch kann ein Astronaut nur an einem Projekt forschen. \n In einer Forschungsstation werden mehrere Forschungsprojekte organisiert. Ein Forschungsprojekt verbessert mehrere Wohncontainer. Zugleich k�nnen mehrere Projekte einen Wohncontainer verbessern.";
            eRAufgabenText.aufgabe[6] = "Eine weitere M�glichkeit Ertr�ge zu erzielen sind Weidesph�ren. Doch bevor wir diese anlegen, werden zun�chst Nutztiere und Stallcontainer ben�tigt. Ein Stallcontainer hat Baukosten, eine eindeutige Containernummer (CNr.), eine Gehegezahl und eine Anzahl der noch freien Gehege. Stallcontainer werden exakt wie Wohncontainer durch Forschungsprojekte verbessert. Mehrere Nutztiere wohnen in einem Stallcontainer. Diese haben Transportkosten, einen Namen und eine Art. Jedes Nutztier kann eindeutig �ber Name und Art identifiziert werden.";


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
