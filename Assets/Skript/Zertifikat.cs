using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using sharpPDF;

 

public class Zertifikat : MonoBehaviour
{
    //public Image myImage;
    // Start is called before the first frame update
    void Start()
    {

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
        myDoc.addImageReference(Application.dataPath + @"\Zertifikatsbilder\Zertifikat.png","Hintergrund");
        myPage.addImage(myDoc.getImageReference("Hintergrund"),0 ,0);
        //Spiel-Screenshot
        myDoc.addImageReference(Application.dataPath + @"\Zertifikatsbilder\Spiel.png","Spiel");
        myPage.addImage(myDoc.getImageReference("Spiel"),239,1691, 1044, 1878);
        //ER-Screenshot
        myDoc.addImageReference(Application.dataPath + @"\Zertifikatsbilder\ERD.png","ERD");
        myPage.addImage(myDoc.getImageReference("ERD"), 239,476, 1044, 1878);

        //Schriftgröße
        int schriftSize = 50;
        //Schriftart AstroSpace: myDoc.getFontReference("AstroSpace")
        myDoc.addTrueTypeFont(Application.dataPath + @"\Font\AstroSpace-eZ2Bg.ttf", "AstroSpace");
        //Schriftart FallingSky: myDoc.getFontReference("FallingSky")
        myDoc.addTrueTypeFont(Application.dataPath + @"\Font\FallingSky-JKwK.ttf", "FallingSky");
        
        //Name und Level
        myPage.addText("Maxi Mustermensch", 513, 2945, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Story.level.ToString(), 2109, 2946, myDoc.getFontReference("AstroSpace"), schriftSize);
        
        //Siedlungsdaten
        myPage.addText(Testing.summeMenschen.ToString(), 355, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.summeTiere.ToString(), 868, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.summeForschungen.ToString(), 1307, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        myPage.addText(Testing.umsatz.ToString(), 1966, 152, myDoc.getFontReference("AstroSpace"), schriftSize);
        
        


        myDoc.createPDF( Application.dataPath + @"\PDF\missionsbestätigung.pdf");
        myPage = null;
        myDoc = null; 
    }
}
