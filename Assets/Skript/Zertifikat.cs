using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sharpPDF;

 

public class Zertifikat : MonoBehaviour
{
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
        pdfPage myPage = myDoc.addPage();
        myPage.addText("Mein Geld: "+Testing.geld.ToString(), 0, 0, myDoc.getFontReference("Helvetica"), 20);
        //myDoc.addImageReference(Application.dataPath + @"\SaveState\ERDScreenshot.png","Bild");
        //myPage.addImage(myDoc.getImageReference("Bild"),400,750);

        myDoc.createPDF( Application.dataPath + @"\PDF\missionsbestätigung.pdf");
        myPage = null;
        myDoc = null; 
    }
}
