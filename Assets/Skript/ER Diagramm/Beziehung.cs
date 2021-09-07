using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beziehung : MonoBehaviour
{
    public string beziehungsName;
    public int instanceID;

    public int objekt1ID;
    public int objekt2ID;

    public string kard1 = "1";
    public string kard2 = "1";

    public bool schwach = false;

    public float x;
    public float y;

    public GameObject objekt1 = null;
    public GameObject objekt2 = null;

    private GameObject kardText1;
    private GameObject kardText2;

    public GameObject linie1;
    public GameObject linie2;

    public GameObject linie;
    public GameObject linienOrdner;

    public Sprite schwachSelected;
    public Sprite schwachOriginal;
    public Sprite Selected;
    public Sprite Original;

    private bool firsttime = true;
    // Start is called before the first frame update
    void Start()
    {
        kardText1 = gameObject.transform.GetChild(2).gameObject;
        kardText2 = gameObject.transform.GetChild(3).gameObject;

        if (firsttime)
        {
            firsttime = false;
            kard1 = "1";
            kard2 = "1";
        }

        instanceID = gameObject.GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        //x und y für Speichern
        beziehungsName = gameObject.name;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.z;

        //Löscht Beziheung wenn Entität gelöscht ansonsten wird instanceID gemerkt von Entität
        if (objekt1 == null)
        {
            if (objekt2 != null)
            {
                objekt2.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            Destroy(linie2);
            ERErstellung.modellObjekte.Remove(gameObject);
            Destroy(gameObject);
            Destroy(this);
        }
        else
        {
            objekt1ID = objekt1.GetInstanceID();
        }
        if (objekt2 == null)
        {
            if (objekt1 != null)
            {
                objekt1.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            Destroy(linie1);
            ERErstellung.modellObjekte.Remove(gameObject);
            Destroy(gameObject);
            Destroy(this);
        }
        else
        {
            objekt2ID = objekt2.GetInstanceID();
        }      
        
        //setzen der Kardinaltiäten, immer 1:n und nicht 1:m
        Utilitys.TextInTMP(kardText1, kard1);
        if (kard1.Equals("n") && kard2.Equals("n"))
        {
            Utilitys.TextInTMP(kardText2, "m");
        }
        else
        {
            Utilitys.TextInTMP(kardText2, kard2);
        }

        //Position von Kardinaltäten, wenn Enität vorhanden, wenn Beziehunge zu sich selbst nimm nicht die Mitte der Entität sondern den Rand (offset)
        if (objekt1 != null)
        {
            int offset=0;
            if (objekt1.Equals(objekt2))
            {
                offset = 1;
            }
            positionOfKardinalitaet(kardText1, objekt1, offset);
            kardText1.SetActive(true);
        }
        else
        {
            kardText1.SetActive(false);
        }

        if (objekt2 != null)
        {
            int offset = 0;
            if (objekt1.Equals(objekt2))
            {
                offset = 2;
            }
            positionOfKardinalitaet(kardText2, objekt2, offset);
            kardText2.SetActive(true);
        }
        else
        {
            kardText2.SetActive(false);
        }
        //wenn Beziehunge zu sich selbst nimm nicht die Mitte der Entität sondern den Rand, Übergabe an Linienzeichnerskript
        if (objekt1!=null&&objekt2!=null&&objekt1.Equals(objekt2))
        {
            linie1.GetComponent<Linienzeichner>().setposition = 1;
            linie2.GetComponent<Linienzeichner>().setposition = 2;
        }
        else
        {
            linie1.GetComponent<Linienzeichner>().setposition = 0;
        }

        //Aussehen (schwach oder nicht schwach) übergeben
        if (schwach)
        {
            gameObject.GetComponent<ERObjekt>().selectedSprite = schwachSelected;
            gameObject.GetComponent<ERObjekt>().originalSprite = schwachOriginal;
        }
        else
        {
            gameObject.GetComponent<ERObjekt>().selectedSprite = Selected;
            gameObject.GetComponent<ERObjekt>().originalSprite = Original;
        }

        //Schau ob keine zwei Beziehungen zwischen den gleichen Entitäten existieren
        bool temp = false;
        foreach(GameObject bez in ERErstellung.modellObjekte)
        {
            if (bez.CompareTag("Beziehung")&&bez!=gameObject&&
                ((bez.GetComponent<Beziehung>().objekt1==objekt1&& bez.GetComponent<Beziehung>().objekt2 == objekt2)||
                 (bez.GetComponent<Beziehung>().objekt2 == objekt1 && bez.GetComponent<Beziehung>().objekt1 == objekt2)))
            {
                temp = true;
            }
        }
        if(temp){
            FehlerAnzeige.fehlertext = "Es dürfen keine zwei Beziehungen zwischen den gleichen Entitäten existieren.";
        }else{
            if(FehlerAnzeige.fehlertext.Equals("Es dürfen keine zwei Beziehungen zwischen den gleichen Entitäten existieren.")){
                FehlerAnzeige.fehlertext = "trigger";
            }
        }
    }

    //wenn geladen werden alle Daten hierdurch geladen
    //Achtung: IDs sind noch alte Werte werden dann auf neue InstanceIDS gesetzt
    internal void setWerte(LoadedBeziehung bez)
    {
        firsttime = false;
        beziehungsName = bez.beziehungsName;
        gameObject.name = bez.beziehungsName;
        instanceID = bez.instanceID;
        objekt1ID = bez.objekt1ID;
        objekt2ID = bez.objekt2ID;
        kard1 = bez.kard1;
        kard2 = bez.kard2;
        schwach = bez.schwach;
        x = bez.x;
        y = bez.y;
    }

    //setzt LinienOrdnern in ER Modell Hintergrund und Linienordner, alle Linien werden dort gespeichert, so sind sie hinter ER-Objekten
    //zeichnet gleich Linien zwischen Objekten
    public void setLinienordner(GameObject lO)
    {
        linienOrdner = lO;

        if (objekt1 != null)
        {
            zeichneLinie(objekt1);
        }
        if (objekt2 != null)
        {
            zeichneLinie(objekt2);
        }
    }

    //bei Klick auf ER Leiste unten Beziehung
    public void erstelleBeziehung()
    {
        //Beziehung immer zu letzt markierten Objekt
        GameObject ent = ERErstellung.selectedGameObjekt;
        int counter = -1;
        if (ent.CompareTag("Attribut"))
        {
            ent = ent.transform.parent.gameObject;
        }
        foreach (GameObject go in ERErstellung.modellObjekte)
        {
            if (go.CompareTag("Entitaet") && go.Equals(ent))
            {
                break;
            }else if (go.CompareTag("Entitaet"))
            {
                counter++;
            }
        }
        //erstellt Linien zwischen Beziehung und Entität
        welcheEntity(1, counter, false);
        welcheEntity(2, counter, false);
    }

    private void positionOfKardinalitaet(GameObject kardtext, GameObject objekt, int offset)   //offset =  0-keiner, 1- rechts, 2-Links
    {
        Vector3 pos1 = getPosition(gameObject);
        Vector3 pos2 = getPosition(objekt);
       
        Vector3[] ecken = new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(ecken);
        //Debug.Log("Ecken:" + ecken[0] + " " + ecken[1] + " " + ecken[2] + " " + ecken[3] + " ");
        //Mittelpunkte sind Ecken der Raute der Beziehung
        Vector3[] mittelpunkte = new Vector3[] { (ecken[0] + ecken[1]) / 2, (ecken[1] + ecken[2]) / 2, (ecken[2] + ecken[3]) / 2, (ecken[3] + ecken[0]) / 2 };
        //Debug.Log("Mittelpunkte:" + mittelpunkte[0] + " " + mittelpunkte[1] + " " + mittelpunkte[2] + " " + mittelpunkte[3] + " ");

        //falls Entität mit sich selbst in Beziehung
        if (offset == 1)
        {
            pos1 = mittelpunkte[0];
        }
        else if (offset == 2)
        {
            pos1 = mittelpunkte[2];
        }

        //rechts 0 Grad, oben 90 Grad
        float winkel =-1* (Vector3.SignedAngle(pos2 - pos1, Vector3.left, Vector3.forward)-180);
        //Debug.Log(winkel);

        Vector3 mittel1 = new Vector3();
        Vector3 mittel2 = new Vector3();
        //bestimme beide Mittelpunkte zwischen denen Kardinalität liegen soll
        //lege Pivot entsprechend fest, sodass Zahl immer außerhalb ist
        if (winkel >= 0 && winkel <= 90)
        {
            mittel1 = mittelpunkte[1];
            mittel2 = mittelpunkte[2];
            kardtext.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        }
        else if (winkel >= 90 && winkel <= 180)
        {
            mittel1 = mittelpunkte[1];
            mittel2 = mittelpunkte[0];
            kardtext.GetComponent<RectTransform>().pivot = new Vector2(1, 0);
        }
        else if (winkel >= 180 && winkel <= 270)
        {
            mittel1 = mittelpunkte[3];
            mittel2 = mittelpunkte[0];
            kardtext.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
        }
        else if (winkel >= 270 && winkel <= 360)
        {
            mittel1 = mittelpunkte[3];
            mittel2 = mittelpunkte[2];
            kardtext.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        }
        //bestimme Schnittpunkt zischen Kante der Beziehung und Linie zwischen Beziehung und Entität
        Vector3 schnittpunkt = LineLineIntersection(pos1, pos2 - pos1, mittel1, mittel2 - mittel1);
        kardtext.transform.position = schnittpunkt;
        
    }

    // aus: https://stackoverflow.com/questions/59449628/check-when-two-vector3-lines-intersect-unity3d
    //linePoint Stützvektor, lineVec1 Richtungsvektor der Geraden
    private Vector3 LineLineIntersection(Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
    {
        Vector3 lineVec3 = linePoint2 - linePoint1;
        Vector3 crossVec1and2 = Vector3.Cross(lineVec1, lineVec2);
        Vector3 crossVec3and2 = Vector3.Cross(lineVec3, lineVec2);

        float planarFactor = Vector3.Dot(lineVec3, crossVec1and2);

        //is coplanar, and not parallel
        if (Mathf.Abs(planarFactor) < 0.0001f
                && crossVec1and2.sqrMagnitude > 0.0001f)
        {
            float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
            return linePoint1 + (lineVec1 * s);            
        }
        else
        {
            return Vector3.zero;
        }
    }
    //bestimmt Mittelpunkt unabhängig von Pivot
    //wenn Beziehung/ Entität bewegt wird Pivotpunkt auf Mauszeiger gesetzt
    private Vector3 getPosition(GameObject @object)
    {
        Vector3[] v = new Vector3[4];
        @object.GetComponent<RectTransform>().GetWorldCorners(v);
        float x = v[0].x + (@object.transform.position.x - v[0].x) / (2 * @object.GetComponent<RectTransform>().pivot.x);
        float y = v[0].z + (@object.transform.position.z - v[0].z) / (2 * @object.GetComponent<RectTransform>().pivot.y);

        return new Vector3(x, 0,y);
    }
    // für Dropdown Menü auswahl welche Entität in Beziehung gesetzt wird
    // einsOderZwei: gibt an ob 1. oder 2. Entität der Beziehung, Bei SCHWACH: 1 Kind 2 Elter
    // option: Eingabe/ Position die von DropDown zurückgeben wird
    // schwachKommen: wahr wenn Schwach und Elter gesucht. Überspringt Kind/ schwache Entität
    public void welcheEntity(int einsOderZwei, int option, bool schwachKommen)
    {
        Start(); //Kardtext1 und 2 muss zugeordnet sein
        if (option == -1)   //Fehler abfangen
        {
            return;
        }
        if (schwach && einsOderZwei == 1) //wenn Kind verändert werden will
        {
            FehlerAnzeige.fehlertext = "Änderung der Entitäten nicht möglich!";
            return;
        }

        //suche Entität welche angeklickt wurde
        GameObject entity = null;
        int z = -1;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (schwachKommen && obj.Equals(objekt1)) { } //überspringe schwache Entität
                else
                {
                    z++;
                }
                if (z == option)
                {
                    entity = obj;
                    break;
                }

            }
        }
        //Erstelle Verbindungslinie zu Entität, lösche alte und erstelle Daten, die Dazugehören in Entität
        //für schwach
        if (schwach && einsOderZwei == 2)
        {
            if (objekt1.Equals(entity))
            {
                FehlerAnzeige.fehlertext = "Es kann keine schwache Entität zu sich selber erstellt werden.";
                return;
            }
            else if (objekt2 != null)
            {
                Destroy(linie2.GetComponent<Linienzeichner>());
                Destroy(linie2);
                objekt1.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            objekt2 = entity;
            objekt1.GetComponent<Entitaet>().vaterEntitaet = entity;
            objekt1.GetComponent<Entitaet>().beziehungen.Add(gameObject);
            linie2 = zeichneLinie(objekt2);
        }
        else if (!entity.Equals(objekt1) && einsOderZwei == 1)
        {
            if (objekt1 != null)
            {
                Destroy(linie1.GetComponent<Linienzeichner>());
                Destroy(linie1);
                objekt1.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            objekt1 = entity;
            objekt1.GetComponent<Entitaet>().beziehungen.Add(gameObject);
            linie1 = zeichneLinie(objekt1);
        }
        else if (!entity.Equals(objekt2) && einsOderZwei == 2)
        {
            if (objekt2 != null)
            {
                Destroy(linie2.GetComponent<Linienzeichner>());
                Destroy(linie2);
                objekt2.GetComponent<Entitaet>().beziehungen.Remove(gameObject);
            }
            objekt2 = entity;
            objekt2.GetComponent<Entitaet>().beziehungen.Add(gameObject);
            linie2 = zeichneLinie(objekt2);
        }
    }


    //zeichen Linie zwichen Enitität (obj) und Beziehung
    //gibt Linie zurück
    private GameObject zeichneLinie(GameObject obj)
    {
        if (linienOrdner != null)
        {
            GameObject templinie = Instantiate(linie, transform);

            templinie.GetComponent<Linienzeichner>().setzeGameObjekte(obj, gameObject);
            templinie.GetComponent<Linienzeichner>().zeichnen = true;
            templinie.transform.SetParent(linienOrdner.transform);

            return templinie;
        }
        return null;
    }

    // von Dropdown der Kardinalität, setzt den ausgewählten Wert auf die Kardinalität und lässt den Text anzeigen
    // einsoderzwei sagt welche Kardinalität getrachtet wird
    // option gibt 0 oder 1 aus für 1 oder n/m
    public void kardinalitaet(int einoderzwei, int option)
    {
        if (einoderzwei == 2)
        {
            if (objekt2 == null)
            {
                return;
            }
            if (option == 0)
            {
                kard2 = "1";
            }
            else
            {
                kard2 = "n";
            }
            kardText2.SetActive(true);

        }
        else
        {
            if (objekt1 == null)
            {
                FehlerAnzeige.fehlertext = "Lege zuerst die Entität fest!";
                return;
            }
            if (option == 0)
            {
                kard1 = "1";
            }
            else
            {
                kard1 = "n";
            }
            kardText1.SetActive(true);

        }
    }
}
