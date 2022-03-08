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
    public GameObject outro;

    // Start is called before the first frame update
    void Start()
    {
        if(!Directory.Exists(Application.streamingAssetsPath + "/PDF/"))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath + "/PDF/");
        }
        
        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"/ missionsbestätigung.pdf";  

    }

    // Update is called once per frame
    void Update()
    {
        
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
        myDoc.addTrueTypeFont(Application.streamingAssetsPath + @"\Font\AstroSpace-eZ2Bg.ttf", "AstroSpace");
        //Schriftart FallingSky: myDoc.getFontReference("FallingSky")
        myDoc.addTrueTypeFont(Application.streamingAssetsPath + @"\Font\FallingSky-JKwK.ttf", "FallingSky");

        //Name und Level
        if (Testing.summeMenschen == 0)
        {
            Mensch mensch = new Mensch("",1);
            myPage.addText(mensch.name, 702, 2945, myDoc.getFontReference("AstroSpace"), 40);
        }
        else
        {
            myPage.addText(Testing.menschen[0].name, 702, 2945, myDoc.getFontReference("AstroSpace"), 40);
        }
        String level = "";

        myPage.addText(Story.level.ToString(), 2109, 2946, myDoc.getFontReference("AstroSpace"), schriftSize);
        
        //Siedlungsdaten
        myPage.addText(Testing.summeMenschen.ToString(), 355, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.summeTiere.ToString(), 868, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.summeForschungen.ToString(), 1307, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.umsatz.ToString(), 1966, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        
        


        myDoc.createPDF( Application.streamingAssetsPath + @"\PDF\missionsbestätigung.pdf");
        myPage = null;
        myDoc = null; 

        Invoke("PrintFiles",2);
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

    public void OpenOutro()
    {
        Invoke("Outro",1);
    }

    void Outro()
    {
        outro.SetActive(true);
    }
    public void skipLastMission()
    {
        Mission.missionsLevel[5] = true;
        Mission.missionsTeilLevel5 = new bool[] { true, true, true };
        Mission.screenshotMission = true;
    }
}
