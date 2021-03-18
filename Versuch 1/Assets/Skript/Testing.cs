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

    public static int geld = 1000;


    public static int umsatz = 10;

    public static int forscher=0;
    public static int feldarbeiter = 0;
    public static int tierpfleger = 0;
    public static int tiere =0;

    public static int summeMenschen = 0;
    public static int summeTiere = 0;
    public static int summeForschungen = 0;


    public GameObject erstellfenster;
    public GameObject infofesnter;

    public static List<Wohncontainer> wohncontainer = new List<Wohncontainer>();
    public static List<Feld> felder = new List<Feld>();
    public static List<Forschung> forschungsstationen = new List<Forschung>();
    public static List<Projekt> forschungsprojekte = new List<Projekt>();
    public static List<Weide> weiden = new List<Weide>();
    public static List<Stallcontainer> stallcontainer = new List<Stallcontainer>();
    public static List<GameObject> gebauedeListe = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        grid = new Gitter(weite, hoehe, zellengroesse);

        //Hintergrund und Camera
        boden.transform.Translate(weite / 2 * zellengroesse , hoehe / 2 * zellengroesse , 1);
        boden.transform.localScale += new Vector3(weite +20 , 1, hoehe+20 );
        boden.transform.Rotate(90f, 180f, 0);
        FehlerAnzeige.fehlertext = "";

        ObjektBewegung.erstellfenster = erstellfenster;
        ObjektBewegung.infoAnzeige = infofesnter;
        

        if (laden)
        {
            laden = false;
            speichermenue.GetComponent<SaveLoad>().laden();
        }


     }

  

  




}



