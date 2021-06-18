using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ERAufgabenText : MonoBehaviour, IPointerClickHandler
{    //Aufgabentext je LvL    
    private string[] aufgabe = { 
                    /*LvL 0*/  "Um den Mars zu besiedeln, müssen Astronautinnen und Astronauten eingeflogen werden. Damit diese auf dem Planeten leben können, werden Wohncontainer benötigt. Dafür wird die Entitymenge Wohncontainer angelegt. Alle Wohncontainer haben gemeinsame Eigenschaften, die Attribute. Sie haben bestimmte Baukosten eine genaue Bettenzahl, die die Menge an beherbergbaren Astronautinnen und Astronauten ausdrückt und ein Attribut für noch freie Betten. Jeder Container hat in der Siedlung eine eindeutige Containernummer, der Primärschlüssel." ,
                    /*LvL 1*/  "Astronautinnen und Astronauten wohnen in (wohntIn) Wohncontainer. Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (n:1). Wichtig ist, dass nur Astronauten eingeflogen werden können, wenn ausreichend Wohncontainer existieren (schwache Entitymenge). Alle Astronauten haben einen Namen und ein Geburtstag, worüber man sie eindeutig bestimmen kann. Für die Anreise fallen bestimmt Anreisegebühren an und jeder hat eine bestimmte Aufgabe in der Siedlung.",
                    /*LvL 2*/  "Eine Möglichkeit Erträge zu erzielen sind Feldsphären in denen Nahrung angebaut wird. Diese haben bestimmte Baukosten, eine genaue Arbeiterzahl und einen Ertrag, den du alle 5 Sol erhältst. Mehrere Astronauten arbeiten in einer Feldsphäre, wobei ein Astronaut nicht auf mehreren Feldsphären gleichzeitig arbeiten kann.",
                    /*LvL 3*/  "Die Siedlung dient vor allem der Forschung, um Sphären und Wohncontainer zu verbessern. Dafür werden Forschungsstationen gebaut. Eine Forschungsstation hat eine eindeutige Stationsnummer, Baukosten und eine bestimmte Spezialisierung. Diese gibt an, für welchen Objekttyp in der Forschungsstation geforscht wird. Für eine Forschungsstation ist genau ein Astronaut verantwortlich.",
                    /*LvL 4*/  "Bislang können in der Siedlung Wohncontainer und Feldsphären erbaut werden. Forschungsprojekte verbessern die Forschungsmerkmale immer für alle zukünftig gebauten Objekte. Ein Forschungsprojekt verbessert daher mehrere Wohncontainer und Feldsphären. Zugleich können mehrere Projekte an einer Feldsphäre, bzw. Wohncontainer forschen. Neben der Verbesserung von Containern und Sphären kann einmalig ein Forschungsprojekt durchgeführt werden, dass an neuen Methoden forscht und so für alle zukünftigen Forschungsprojekte der jeweiligen Station die Projektkosten verbessert. Diese Möglichkeit betrifft jede errichtete Forschungsstation.",
                    /*LvL 5*/  "Bislang können in der Siedlung neben Wohncontainer auch Feldsphären erbaut werden. Ein Forschungsprojekt verbessert daher auch mehrere Feldsphären. Zugleich können mehrere Projekte an einer Feldsphäre forschen. Neben der Verbesserung von Containern und Sphären kann einmalig ein Forschungsprojekt durchgeführt werden, dass an neuen Methoden forscht und so für alle zukünftigen Forschungsprojekte der jeweiligen Station die Projektkosten verbessert. Diese Möglichkeit betrifft jede errichtete Forschungsstation.",
                    /*LvL 6*/  "Eine weitere Möglichkeit Erträge zu erzielen sind Weidesphären. Dafür werden zunächst Nutztiere und Stallcontainer benötigt. Um ein Nutztier einfliegen zu lassen, müssen vorher Stallcontainer existieren. Ein Stallcontainer hat Baukosten, eine Containernummer, eine Gehegezahl und eine Anzahl der noch freien Gehege. Stallcontainer werden exakt wie Wohncontainer durch Forschungsprojekte verbessert. Mehrere Nutztiere wohnen in einem Stallcontainer. Diese haben Transportkosten, einen Namen und eine Art. Jedes Nutztier kann eindeutig über Name und Art identifiziert werden.",
                    /*LvL 7*/  "Um Erträge zu erhalten arbeiten mehrere Nutztiere auf einer Weidesphäre. Diese hat eine eindeutige Weidenummer, einen Ertrag, eine Tieranzahl und eine Arbeiterzahl, die sie benötigt. Somit arbeiten mehrere Astronauten in einer Weidesphäre, jedoch wie bei Feldsphären arbeitet ein Astronaut nur in einer Weidesphäre. Wie bei Feldsphären, werden zukünftig erbaute Weidesphären von einem Forschungsprojekt verbessert und mehrere Projekte können eine Weidesphäre verbessern.",
                                
                    /*LvL Ziel*/   //ZIELAUFGABE FEHLT NOCH
                                };
    private List<int>[] entitys = {
                 /*LvL 0*/ new List<int> { 17,23,26 },
                 /*LvL 1*/ new List<int>{0,2,6,3,24,35},
                 /*LvL 2*/ new List<int>{6},
                 /*LvL 3*/ new List<int>{},
                 /*LvL 4*/ new List<int>{},
                 /*LvL 5*/ new List<int>{},
                 /*LvL 6*/ new List<int>{},
                 /*LvL 7*/ new List<int>{},
    };

    private List<int>[] attribute = {
                /*LvL 0*/ new List<int> {35, 38,52,51,61 },
                 /*LvL 1*/ new List<int>{38,41,53,60},
                 /*LvL 2*/ new List<int>{15,18,21},
                 /*LvL 3*/ new List<int>{},
                 /*LvL 4*/ new List<int>{},
                 /*LvL 5*/ new List<int>{},
                 /*LvL 6*/ new List<int>{},
                 /*LvL 7*/ new List<int>{},
    };

    private List<int>[] beziehungen = {
                 /*LvL 0*/ new List<int> {  },
                 /*LvL 1*/ new List<int>{3,1},
                 /*LvL 2*/ new List<int>{30},
                 /*LvL 3*/ new List<int>{},
                 /*LvL 4*/ new List<int>{},
                 /*LvL 5*/ new List<int>{},
                 /*LvL 6*/ new List<int>{},
                 /*LvL 7*/ new List<int>{},
    };

    private List<int>[] kardinalitaet = {
                 /*LvL 0*/ new List<int> {  },
                 /*LvL 1*/ new List<int>{8,9,17},
                 /*LvL 2*/ new List<int>{28,32},
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
        Debug.Log(index);
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
                if (kardinalitaet[Story.level].Contains(index))
                {
                    Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                    vertexColors[vertexIndex + 0] = Color.cyan;
                    vertexColors[vertexIndex + 1] = Color.cyan;
                    vertexColors[vertexIndex + 2] = Color.cyan;
                    vertexColors[vertexIndex + 3] = Color.cyan;
                }
            }

            m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
        }

    }
}
