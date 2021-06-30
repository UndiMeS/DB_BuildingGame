using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ERAufgabenText : MonoBehaviour, IPointerClickHandler
{    //Aufgabentext je LvL    
    private string[] aufgabe = { 
                    /*LvL 0*/  "Um den Mars mit Astronauten und Astronautinnen zu besiedeln werden Wohncontainer benötigt. Dafür wird die Entitymenge Wohncontainer angelegt. Alle Wohncontainer haben gemeinsame Eigenschaften, die Attribute. Sie haben bestimmte Baukosten eine genaue Bettenzahl, die die Menge an beherbergbaren Astronautinnen und Astronauten ausdrückt und ein Attribut für noch freie Betten. Jeder Container hat in der Siedlung eine eindeutige Containernummer, der Primärschlüssel." ,
                    /*LvL 1*/  "Die Astronauten können nur dann eingeflogen werden, wenn ausreichend Wohncontainer existieren. Astronaut ist daher eine schwache Entitymenge. (Hinweis: Schwache Entitymengen erkennst du im Spiel daran, dass damit mögliche Handlungen nur in der Anzeige der zugehörigen 'starken Entitymenge' möglich sind.) \n Astronauten wohnen in Wohncontainern (Beziehung 'wohnt'). Jeder Astronaut ist genau einem Container zugeordnet und teilt sich diesen mit anderen (Kardinaliät n:1). Alle Astronauten haben einen Namen und ein Geburtstag, worüber man sie eindeutig bestimmen kann. Für die Anreise fallen bestimmt Anreisegebühren an und jeder hat eine bestimmte Aufgabe in der Siedlung (Weideastronaut (Symbol Mistgabel), Forschungsastronaut (Symbol Reagenzglas) und Feldastronaut (Symbol Weizenähre)).",
                    /*LvL 2*/  "Eine Möglichkeit Erträge zu erzielen sind Feldsphären in denen Nahrung angebaut wird. Diese haben bestimmte Baukosten, eine genaue Arbeiterzahl und einen Ertrag, den du alle 5 Sol erhältst. Mehrere Astronauten arbeiten in einer Feldsphäre, wobei ein Astronaut nicht auf mehreren Feldsphären gleichzeitig arbeiten kann. Jede Feldsphäre kann eindeutig über ihre Feldnummer bestimmt werden.",
                    /*LvL 3*/  "Die Siedlung dient vor allem der Forschung, um Sphären und Wohncontainer zu verbessern. Dafür werden Forschungsstationen gebaut. Eine Forschungsstation hat eine eindeutige Stationsnummer, Baukosten und eine bestimmte Spezialisierung. Diese gibt an, für welchen Objekttyp in der Forschungsstation geforscht wird. Für eine Forschungsstation ist genau ein Astronaut verantwortlich.",
                    /*LvL 4*/  "Verbesserungen werden durch Forschungsprojekte erreicht. Attribute von Sphären und Containern können mehrfach erforscht und so mehrfach verbessert werden. Ein Forschungsprojekt hat somit ein bestimmtes Forschungsmerkmal und eine Forschungsstufe. Darüber kann ein Forschungsprojekt eindeutig ermittelt werden. Jedes Forschungsprojekt erzielt einen Verbesserungsfaktor, benötigt eine bestimmte Arbeiterzahl und Projektkosten. Forschungsprojekte können nur angelegt werden, wenn die passende Forschungsstation bereits existiert. Eine Forschungsstation organisiert mehrere Forschungsprojekte. Mehrere Astronauten können in einem Forschungsprojekt forschen, jedoch kann ein Astronaut nur an einem Projekt forschen. \nForschungsprojekte verbessern die Forschungsmerkmale immer für alle zukünftig gebauten Objekte. Ein Forschungsprojekt verbessert mehrere Wohncontainer. Zugleich können mehrere Projekte einen Wohncontainer verbessern.",
                    /*LvL 5*/  "Bislang können in der Siedlung neben Wohncontainer auch Feldsphären erbaut werden. Ein Forschungsprojekt verbessert daher auch mehrere Feldsphären. Zugleich können mehrere Projekte an einer Feldsphäre forschen. Neben der Verbesserung von Containern und Sphären kann einmalig ein Forschungsprojekt durchgeführt werden, dass an neuen Methoden forscht und so für alle zukünftigen Forschungsprojekte die Projektkosten verbessert. Diese Möglichkeit betrifft die Forschungsprojekte von jeder errichteten Forschungsstation.",
                    /*LvL 6*/  "Eine weitere Möglichkeit Erträge zu erzielen sind Weidesphären. Doch bevor wir diese anlegen, werden zunächst Nutztiere und Stallcontainer benötigt. Um ein Nutztier einfliegen zu lassen, müssen vorher Stallcontainer existieren. Ein Stallcontainer hat Baukosten, eine Containernummer, eine Gehegezahl und eine Anzahl der noch freien Gehege. Stallcontainer werden exakt wie Wohncontainer durch Forschungsprojekte verbessert. Mehrere Nutztiere wohnen in einem Stallcontainer. Diese haben Transportkosten, einen Namen und eine Art. Jedes Nutztier kann eindeutig über Name und Art identifiziert werden.",
                    /*LvL 7*/  "Um Erträge zu erhalten arbeiten mehrere Nutztiere auf einer Weidesphäre. Diese hat eine eindeutige Weidenummer, einen Ertrag, eine Tieranzahl und eine Arbeiterzahl, die sie benötigt. Somit arbeiten mehrere Astronauten in einer Weidesphäre, jedoch wie bei Feldsphären arbeitet ein Astronaut nur in einer Weidesphäre. Wie bei Feldsphären, werden zukünftig erbaute Weidesphären von einem Forschungsprojekt verbessert und mehrere Projekte können eine Weidesphäre verbessern.",
                                
                    /*LvL Ziel*/   //ZIELAUFGABE FEHLT NOCH
                                };
    public  List<string>[] entitys = {
                 /*LvL 0*/ new List<string>{"Wohncontainer" },
                 /*LvL 1*/ new List<string>{"Astronauten", "Astronaut", "existieren", "schwache","Entitymenge"},
                 /*LvL 2*/ new List<string>{"Feldsphären", "Feldsphäre"},
                 /*LvL 3*/ new List<string>{"Forschungsstationen","Forschungsstation"},
                 /*LvL 4*/ new List<string>{"Forschungsprojekte","Forschungsprojekt","bereits","existiert"},
                 /*LvL 5*/ new List<string>{},
                 /*LvL 6*/ new List<string>{"Nutztiere","Stallcontainer"},
                 /*LvL 7*/ new List<string>{"Weidesphäre"},
    };

    private List<string>[] attribute = {
                /*LvL 0*/ new List<string> {"Baukosten", "freie", "Betten", "Bettenzahl", "Containernummer" },
                 /*LvL 1*/ new List<string>{"Namen","Geburtstag","Anreisegebühren","Aufgabe"},
                 /*LvL 2*/ new List<string>{"Baukosten","Arbeiterzahl","Ertrag","Feldnummer"},
                 /*LvL 3*/ new List<string>{"Stationsnummer","Baukosten","Spezialisierung"},
                 /*LvL 4*/ new List<string>{"Forschungsmerkmal", "Forschungsstufe", "Verbesserungsfaktor","Arbeiterzahl","Projektkosten"},
                 /*LvL 5*/ new List<string>{},
                 /*LvL 6*/ new List<string>{"Baukosten","Gehegezahl","freien","Gehege","Transportkosten","Namen","Art"},
                 /*LvL 7*/ new List<string>{"Weidenummer","Ertrag","Tieranzahl","Arbeiterzahl"},
    };

    private List<string>[] beziehungen = {
                 /*LvL 0*/ new List<string> {  },
                 /*LvL 1*/ new List<string>{"wohnt", "wohnen"},
                 /*LvL 2*/ new List<string>{"arbeiten"},
                 /*LvL 3*/ new List<string>{"verantwortlich"},
                 /*LvL 4*/ new List<string>{"organisiert","verbessert","forschen","forscht"},
                 /*LvL 5*/ new List<string>{"verbessert","forscht"},
                 /*LvL 6*/ new List<string>{"verbessert","leben"},
                 /*LvL 7*/ new List<string>{"verbessert","arbeitet","arbeiten"},
    };

    private List<string>[] kardinalitaet = {
                 /*LvL 0*/ new List<string> {  },
                 /*LvL 1*/ new List<string>{"n:1","jeder", "anderen","genau"},
                 /*LvL 2*/ new List<string>{"Mehrere"},
                 /*LvL 3*/ new List<string>{"genau"},
                 /*LvL 4*/ new List<string>{"mehrere","Mehrere"},
                 /*LvL 5*/ new List<string>{"mehrere","Mehrere"},
                 /*LvL 6*/ new List<string>{"mehrere","Mehrere"},
                 /*LvL 7*/ new List<string>{"mehrere","Mehrere"},
    };

    private TextMeshProUGUI m_TextMeshPro;

    //Werte für Klickzähler
    private int i = 0;//Zählvariable für Klicks
    public GameObject restKlicks;
    public GameObject absolutKlicks;
    public static bool werteGesetzt = false; //Wird in ERAufgabe.cs auf false gesetzt, wenn ER-Level erfüllt wurde.
    private int[] lvlKlicks = {10,15,10,10,10,10,10,10}; //Klickguthaben der einzelnen Levels

    private void Start()
    {
        m_TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        m_TextMeshPro.ForceMeshUpdate();
        
        //Setze die Startwerte des Klick-Zählers
        Utilitys.TextInTMP(restKlicks, lvlKlicks[Story.level].ToString());
        Utilitys.TextInTMP(absolutKlicks, lvlKlicks[Story.level].ToString());

    }
    private void Update()
    {
        //Veränderung des absoluten Klickwerts bei neuem ER-Level
        Utilitys.TextInTMP(absolutKlicks, lvlKlicks[Story.level].ToString());
        
        //Veränderung des relativen Start - Klickwerts bei neuem ER-Level
        if(Story.level != 0 && werteGesetzt == false){ //werteGesetzt wird in ERAufgabe auf false gesetzt wenn Level erfüllt
            //Prüfe, ob vorheriges Level erfüllt wurde.
            if(Story.lvl[Story.level - 1]){
                i = 0;
                Utilitys.TextInTMP(restKlicks, (lvlKlicks[Story.level]).ToString());
                werteGesetzt = true;
            }
        }
    }

    internal void textAnzeigen(int lvl)
    {
        Utilitys.TextInTMP(gameObject, aufgabe[lvl]);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int index = TMP_TextUtilities.FindIntersectingWord(m_TextMeshPro, eventData.position, eventData.enterEventCamera);
        //welche Position n:1
        //Debug.Log(TMP_TextUtilities.FindIntersectingCharacter(m_TextMeshPro, eventData.position, eventData.enterEventCamera,true));
        
        if(lvlKlicks[Story.level] - i > 0){   
            Utilitys.TextInTMP(restKlicks, (lvlKlicks[Story.level] - i -1).ToString());
            i++;

            markieren(index,0,""); 

            if(i == 1 && Story.level == 0){
                FehlerAnzeige.tutorialtext_ER = "Du kannst für dieses Teildiagramm auf "+ lvlKlicks[Story.level]+" Wörter klicken, um richtige Schlüsselwörter herauszufinden und zu markieren!";
            }

        }else{
                FehlerAnzeige.fehlertext="Du hast nicht mehr Klicks zur Verfügung!";
        }
    }

    private void markieren(int index, int leftRight, string entAttBez)
    {
        if (index > 0)
        {
            if(true){
                TMP_WordInfo info = m_TextMeshPro.textInfo.wordInfo[index];
                for (int i = 0; i < info.characterCount; ++i)
                {
                    int charIndex = info.firstCharacterIndex + i;
                    int meshIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].materialReferenceIndex;
                    int vertexIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].vertexIndex;

                    if (entitys[Story.level].Contains(info.GetWord())&&entAttBez=="")
                    {
                        Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                        vertexColors[vertexIndex + 0] = Color.red;
                        vertexColors[vertexIndex + 1] = Color.red;
                        vertexColors[vertexIndex + 2] = Color.red;
                        vertexColors[vertexIndex + 3] = Color.red;
                    }
                    if (attribute[Story.level].Contains(info.GetWord()) && (entAttBez == "Att" || entAttBez == ""))
                    {
                        Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                        vertexColors[vertexIndex + 0] = Color.green;
                        vertexColors[vertexIndex + 1] = Color.green;
                        vertexColors[vertexIndex + 2] = Color.green;
                        vertexColors[vertexIndex + 3] = Color.green;
                    }
                    if (attribute[Story.level].Contains(m_TextMeshPro.textInfo.wordInfo[index - 1].GetWord())&&leftRight!=1&&(entAttBez=="Att"||entAttBez==""))
                    {
                        markieren(index - 1,-1,"Att");
                    }
                    else if (attribute[Story.level].Contains(m_TextMeshPro.textInfo.wordInfo[index + 1].GetWord())&&leftRight!=-1 && (entAttBez == "Att" || entAttBez == ""))
                    {
                        markieren(index + 1,1,"Att");
                    }
                    if (beziehungen[Story.level].Contains(info.GetWord()) && (entAttBez == "Bez" || entAttBez == ""))
                    {
                        Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                        vertexColors[vertexIndex + 0] = Color.blue;
                        vertexColors[vertexIndex + 1] = Color.blue;
                        vertexColors[vertexIndex + 2] = Color.blue;
                        vertexColors[vertexIndex + 3] = Color.blue;
                    }
                    if (beziehungen[Story.level].Contains(m_TextMeshPro.textInfo.wordInfo[index - 1].GetWord()) && leftRight != 1 && (entAttBez == "Bez" || entAttBez == ""))
                    {
                        markieren(index - 1, -1, "Bez");
                    }
                    else if (beziehungen[Story.level].Contains(m_TextMeshPro.textInfo.wordInfo[index + 1].GetWord()) && leftRight != -1 && (entAttBez == "Bez" || entAttBez == ""))
                    {
                        markieren(index + 1, 1, "Bez");
                    }
                    if (kardinalitaet[Story.level].Contains(info.GetWord()) && entAttBez == "")
                    {
                        Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                        vertexColors[vertexIndex + 0] = Color.gray;
                        vertexColors[vertexIndex + 1] = Color.gray;
                        vertexColors[vertexIndex + 2] = Color.gray;
                        vertexColors[vertexIndex + 3] = Color.gray;
                    }
                    if (kardinalitaet[Story.level].Contains(m_TextMeshPro.textInfo.wordInfo[index - 1].GetWord()) && leftRight != 1 && (entAttBez == "Kard" || entAttBez == ""))
                    {
                        markieren(index - 1, -1, "Kard");
                    }
                    else if (kardinalitaet[Story.level].Contains(m_TextMeshPro.textInfo.wordInfo[index + 1].GetWord()) && leftRight != -1 && (entAttBez == "Kard" || entAttBez == ""))
                    {
                        markieren(index + 1, 1, "Kard");
                    }
                    //Lvl 1 (n:1)
                    if(Story.level==1 && (info.GetWord() == "1" || info.GetWord() == "n"))
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            meshIndex = m_TextMeshPro.textInfo.characterInfo[164 + k].materialReferenceIndex;
                            vertexIndex = m_TextMeshPro.textInfo.characterInfo[164 + k].vertexIndex;
                            Color32[] vertexColors = m_TextMeshPro.textInfo.meshInfo[meshIndex].colors32;
                            vertexColors[vertexIndex + 0] = Color.gray;
                            vertexColors[vertexIndex + 1] = Color.gray;
                            vertexColors[vertexIndex + 2] = Color.gray;
                            vertexColors[vertexIndex + 3] = Color.gray;
                        } 
                    }
                }
                m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);  

            }
        }
    }
}
