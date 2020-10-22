using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject boden;

    //Grundlegende Werte, die verändert werden können
    public static int weite=20;
    public static int hoehe=13;
    public static int zellengroesse=10;
    public static int geld = 100000;

    public static Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(weite, hoehe, zellengroesse);
        int KameraX = weite / 2 * zellengroesse;
        int KameraY = hoehe / 2 * zellengroesse;
        int KameraZ = -1 * Mathf.Max(hoehe, weite) / 2 * zellengroesse;

        //Hintergrund und Camera
        boden.transform.Translate(weite / 2 * zellengroesse , hoehe / 2 * zellengroesse , 1);
        boden.transform.localScale += new Vector3(weite +20 , 1, hoehe+20 );
        boden.transform.Rotate(90f, 180f, 0);
        GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(KameraX, KameraY, KameraZ);

     }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    


}



