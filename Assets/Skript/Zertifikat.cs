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
        pdfDocument myDoc = new pdfDocument("TUTORIAL","ME");
        pdfPage myPage = myDoc.addPage();
        myPage.addText("Hello World!", 200, 450, myDoc.getFontReference("Helvetica"), 20);
        //myDoc.addImageReference(@"C:\Users\marcel\Desktop\UndiMeS_GIT\DB_BuildingGame\Assets\SaveState\ERDScreenshot.png","Bild");
        //myPage.addImage(myDoc.getImageReference("Bild"),400,750);

        myDoc.createPDF(@"C:\Users\marcel\Desktop\UndiMeS_GIT\DB_BuildingGame\Assets\PDF\test.pdf");
        myPage = null;
        myDoc = null; 
    }
}
