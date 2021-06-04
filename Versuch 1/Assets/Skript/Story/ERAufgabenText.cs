using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ERAufgabenText : MonoBehaviour, IPointerClickHandler
{    //Aufgabentext je LvL    
    private string[] aufgabe = { 
                    /*LvL 0*/  "Um den Mars zu besiedeln, m�ssen Astronauten eingeflogen werden. Damit diese auf dem Planeten leben k�nnen, werden Wohncontainer ben�tigt. Daf�r wird die Entitymenge Wohncontainer angelegt. Alle Wohncontainer haben gemeinsame Eigenschaften, die Attribute. Sie haben bestimmte Baukosten eine genaue Bettenzahl, die die Menge an beherbergbaren Astronauten ausdr�ckt und ein Attribut f�r noch freie Betten. Jeder Container hat in der Siedlung eine eindeutige Containernummer, der Prim�rschl�ssel." ,
                    /*LvL 1*/  "Astronauten wohnen in (wohntIn) Wohncontainer. Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (n:1). Wichtig ist, dass nur Astronauten eingeflogen werden k�nnen, wenn ausreichend Wohncontainer existieren (schwache Entitymenge). Alle Astronauten haben einen Namen und ein Geburtstag, wor�ber man sie eindeutig bestimmen kann. F�r die Anreise fallen bestimmt Anreisegeb�hren an und jeder hat eine bestimmte Aufgabe in der Siedlung.",
                    /*LvL 2*/  "Eine M�glichkeit Ertr�ge zu erzielen sind Feldsph�ren in denen Nahrung angebaut wird. Diese haben bestimmte Baukosten, eine genaue Arbeiterzahl und einen Ertrag, den du alle 5 Sol erh�ltst. Mehrere Astronauten arbeiten in einer Feldsph�re, wobei ein Astronaut nicht auf mehreren Feldsph�ren gleichzeitig arbeiten kann.",
                    /*LvL 3*/  "Die Siedlung dient vor allem der Forschung, um Sph�ren und Wohncontainer zu verbessern. Daf�r werden Forschungsstationen gebaut. Eine Forschungsstation hat eine eindeutige Stationsnummer, Baukosten und eine bestimmte Spezialisierung. Diese gibt an, f�r welchen Objekttyp in der Forschungsstation geforscht wird. F�r eine Forschungsstation ist genau ein Astronaut verantwortlich.",
                    /*LvL 4*/  "Verbesserungen werden durch Forschungsprojekte erreicht. Attribute von Sph�ren und Wohncontainer k�nnen X mal erforscht und so mehrfach verbessert werden. Ein Forschungsprojekt hat somit ein bestimmtes Forschungsmerkmal und eine Forschungsstufe. Dar�ber kann ein Forschungsprojekt eindeutig ermittelt werden. Jedes Forschungsprojekt erzielt einen Verbesserungsfaktor, ben�tigt eine bestimmte Arbeiterzahl und Projektkosten. Forschungsprojekte k�nnen nur angelegt werden, wenn die passende Forschungsstation bereits existiert. Eine Forschungsstation organisiert mehrere Forschungsprojekte. Mehrere Astronauten k�nnen in einem Forschungsprojekt forschen, jedoch kann ein Astronaut nur an einem Projekt forschen.",
                    /*LvL 5*/  "Bislang k�nnen in der Siedlung Wohncontainer und Feldsph�ren erbaut werden. Forschungsprojekte verbessern die Forschungsmerkmale immer f�r alle zuk�nftig gebauten Objekte. Ein Forschungsprojekt verbessert daher mehrere Wohncontainer und Feldsph�ren. Zugleich k�nnen mehrere Projekte an einer Feldsph�re, bzw. Wohncontainer forschen. Neben der Verbesserung von Containern und Sph�ren kann einmalig ein Forschungsprojekt durchgef�hrt werden, dass an neuen Methoden forscht und so f�r alle zuk�nftigen Forschungsprojekte der jeweiligen Station die Projektkosten verbessert. Diese M�glichkeit betrifft jede errichtete Forschungsstation.",
                    /*LvL 6*/  "Eine weitere M�glichkeit Ertr�ge zu erzielen sind Weidesph�ren. Daf�r werden zun�chst Nutztiere und Stallcontainer ben�tigt. Um ein Nutztier einfliegen zu lassen, m�ssen vorher Stallcontainer existieren. Ein Stallcontainer hat Baukosten, eine Containernummer, eine Gehegezahl und eine Anzahl der noch freien Gehege. Stallcontainer werden exakt wie Wohncontainer durch Forschungsprojekte verbessert. Mehrere Nutztiere wohnen in einem Stallcontainer. Diese haben Transportkosten, einen Namen und eine Art. Jedes Nutztier kann eindeutig �ber Name und Art identifiziert werden.",
                    /*LvL 7*/  "Um Ertr�ge zu erhalten arbeiten mehrere Nutztiere auf einer Weidesph�re. Diese hat eine eindeutige Weidenummer, einen Ertrag, eine Tieranzahl und eine Arbeiterzahl, die sie ben�tigt. Somit arbeiten mehrere Astronauten in einer Weidesph�re, jedoch wie bei Feldsph�ren arbeitet ein Astronaut nur in einer Weidesph�re. Wie bei Feldsph�ren, werden zuk�nftig erbaute Weidesph�ren von einem Forschungsprojekt verbessert und mehrere Projekte k�nnen eine Weidesph�re verbessern.",
                                
                    /*LvL Ziel*/   //ZIELAUFGABE FEHLT NOCH
                                };
    private List<int>[] entitys = {/*LvL 0*/ new List<int> { 17,23,26 },
                 /*LvL 1*/ new List<int>{0,6,24,35},
                 /*LvL 2*/ new List<int>{6},
                 /*LvL 3*/ new List<int>{},
                 /*LvL 4*/ new List<int>{},
                 /*LvL 5*/ new List<int>{},
                 /*LvL 6*/ new List<int>{},
                 /*LvL 7*/ new List<int>{},
    };

    private List<int>[] attribute = {/*LvL 0*/ new List<int> {35, 38,52,51,61 },
                 /*LvL 1*/ new List<int>{38,41,53,60},
                 /*LvL 2*/ new List<int>{15,18,21},
                 /*LvL 3*/ new List<int>{},
                 /*LvL 4*/ new List<int>{},
                 /*LvL 5*/ new List<int>{},
                 /*LvL 6*/ new List<int>{},
                 /*LvL 7*/ new List<int>{},
    };

    private List<int>[] beziehungen = {/*LvL 0*/ new List<int> {  },
                 /*LvL 1*/ new List<int>{3,1},
                 /*LvL 2*/ new List<int>{30},
                 /*LvL 3*/ new List<int>{},
                 /*LvL 4*/ new List<int>{},
                 /*LvL 5*/ new List<int>{},
                 /*LvL 6*/ new List<int>{},
                 /*LvL 7*/ new List<int>{},
    };

    private TextMeshProUGUI m_TextMeshPro;

    private void Start()
    {
        m_TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        m_TextMeshPro.ForceMeshUpdate();
    }

    internal void textAnzeigen(int lvl)
    {
        Utilitys.TextInTMP(gameObject, aufgabe[lvl]);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int index = TMP_TextUtilities.FindIntersectingWord(m_TextMeshPro, eventData.position, eventData.enterEventCamera);
        //Debug.Log(index);
        if (index != -1)
        {
            TMP_WordInfo info = m_TextMeshPro.textInfo.wordInfo[index];
            for (int i = 0; i < info.characterCount; ++i)
            {
                int charIndex = info.firstCharacterIndex + i;
                int meshIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].materialReferenceIndex;
                int vertexIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].vertexIndex;

                if (entitys[Story.level].Contains(index))
                {
                    Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                    vertexColors[vertexIndex + 0] = Color.red;
                    vertexColors[vertexIndex + 1] = Color.red;
                    vertexColors[vertexIndex + 2] = Color.red;
                    vertexColors[vertexIndex + 3] = Color.red;
                }
                if (attribute[Story.level].Contains(index))
                {
                    Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                    vertexColors[vertexIndex + 0] = Color.green;
                    vertexColors[vertexIndex + 1] = Color.green;
                    vertexColors[vertexIndex + 2] = Color.green;
                    vertexColors[vertexIndex + 3] = Color.green;
                }
                if (beziehungen[Story.level].Contains(index))
                {
                    Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                    vertexColors[vertexIndex + 0] = Color.blue;
                    vertexColors[vertexIndex + 1] = Color.blue;
                    vertexColors[vertexIndex + 2] = Color.blue;
                    vertexColors[vertexIndex + 3] = Color.blue;
                }
            }

            m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
        }

    }
}
