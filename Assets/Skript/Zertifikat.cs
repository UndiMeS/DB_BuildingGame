using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using sharpPDF;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using System;

public class Zertifikat : MonoBehaviour
{
    string path = null;

    // Start is called before the first frame update
    void Start()
    {
        if(!Directory.Exists(Application.streamingAssetsPath + "/PDF/"))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath + "/PDF/");
        }
        
        path = Application.streamingAssetsPath + "/PDF/missionsbestätigung.pdf";  

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bye()
    {
        Invoke("PrintFiles",4);
    }

    public void CreatePDF()
    {
        pdfDocument myDoc = new pdfDocument("Missionsbestätigung","UndiMeS");
        pdfPage myPage = myDoc.addPage(3508, 2480);
        
        
        //Hintergrundbild
        myDoc.addImageReference(Application.streamingAssetsPath + @"\Zertifikatsbilder\Zertifikat.png","Hintergrund");
        myPage.addImage(myDoc.getImageReference("Hintergrund"),0 ,0);
        //Spiel-Screenshot
        myDoc.addImageReference(Application.streamingAssetsPath + @"\Zertifikatsbilder\Spiel.png","Spiel");
        myPage.addImage(myDoc.getImageReference("Spiel"),241,1692, 1044, 1878);
        //ER-Screenshot
        myDoc.addImageReference(Application.streamingAssetsPath + @"\Zertifikatsbilder\ERD.png","ERD");
        myPage.addImage(myDoc.getImageReference("ERD"), 241,478, 1044, 1878);

        //Schriftgröße
        int schriftSize = 50;
        //Schriftart AstroSpace: myDoc.getFontReference("AstroSpace")
        myDoc.addTrueTypeFont(Application.dataPath + @"\Font\AstroSpace-eZ2Bg.ttf", "AstroSpace");
        //Schriftart FallingSky: myDoc.getFontReference("FallingSky")
        myDoc.addTrueTypeFont(Application.dataPath + @"\Font\FallingSky-JKwK.ttf", "FallingSky");
        
        //Name und Level
        myPage.addText(Testing.menschen[0].name, 702, 2945, myDoc.getFontReference("AstroSpace"), 40);
        myPage.addText(Story.level.ToString(), 2109, 2946, myDoc.getFontReference("AstroSpace"), schriftSize);
        
        //Siedlungsdaten
        myPage.addText(Testing.summeMenschen.ToString(), 355, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.summeTiere.ToString(), 868, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.summeForschungen.ToString(), 1307, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.umsatz.ToString(), 1966, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        
        


        myDoc.createPDF( Application.streamingAssetsPath + @"\PDF\missionsbestätigung.pdf");
        myPage = null;
        myDoc = null; 

        //Button erstellt erst PDF und ruft dann GO() auf (Drucken PDF und  Spiel beendet (ladeMenu))
        Bye();
    }
    public void PrintFiles() 
    {
        /*
        Debug.Log(path);
        if (path == null)
            return;

        if (File.Exists(path))
        {
            Debug.Log("file found");
        }
        else
        {
            Debug.Log("file not found");
            return;
        }
        */
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.FileName = path;

        process.Start();

        //Beende Spiel und lade Menu
        Testing.resetAll();
        SceneManager.LoadScene(0);
    }
}
