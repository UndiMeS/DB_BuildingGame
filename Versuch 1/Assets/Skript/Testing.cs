using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Grundlegende Methoden
public class Testing : MonoBehaviour
{
    public static bool laden = false;
    public GameObject speichermenue;

    public GameObject boden;
    public GameObject fehlermeldung;

    //Grundlegende Werte, die verändert werden können
    public static int weite=20;
    public static int hoehe=13;
    public static int zellengroesse = 10;
    public static Gitter grid;

    public static int objektGebaut;
    public static GameObject gebautesObjekt;

    public static int geld = 8800;//800


    public static int umsatz = 0;

    public static int forscher=200;
    public static int feldarbeiter =0;
    public static int tierpfleger = 0;
    public static int tiere =0;

    public static int summeMenschen = 0;
    public static int summeTiere = 0;
    public static int summeForschungen = 0;

    private bool zuvorNichtAn;

    public GameObject erstellfenster;
    public GameObject infofesnter;

    public PauseMenu pausemenu;
    public GameObject zusatz;

    public static List<Wohncontainer> wohncontainer = new List<Wohncontainer>();
    public static List<Mensch> menschen = new List<Mensch>();
    public static List<Feld> felder = new List<Feld>();
    public static List<Forschung> forschungsstationen = new List<Forschung>();
    public static List<Projekt> forschungsprojekte = new List<Projekt>();
    public static List<Weide> weiden = new List<Weide>();
    public static List<Stallcontainer> stallcontainer = new List<Stallcontainer>();
    public static List<GameObject> gebauedeListe = new List<GameObject>();
    public static List<Tiere> tier = new List<Tiere>();

    // Start is called before the first frame update
    void Start()
    {
        grid = new Gitter(weite, hoehe, zellengroesse);

        //Hintergrund und Camera
        boden.transform.localPosition = new Vector3(70,  6, -70);
        boden.transform.localScale = new Vector3(30000,30000,200);
        boden.transform.localRotation = Quaternion.Euler(42, 222, -148);
        FehlerAnzeige.fehlertext = "";

        ObjektBewegung.erstellfenster = erstellfenster;
        ObjektBewegung.infoAnzeige = infofesnter;
        

        if (laden)
        {
            laden = false;
            speichermenue.GetComponent<SaveLoad>().laden();
        }

    }

    private void Update()
    {
        if (geld < 25 && zuvorNichtAn)
        {
            pausemenu.ObjectAnzeigen(zusatz);
            zusatz.GetComponent<Aufgaben>().openAufgabe();
            zuvorNichtAn = false;
        }
        else if(geld>=25)
        {
            zuvorNichtAn = true;
        }
    }






}



