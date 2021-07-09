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
        pdfPage myPage = myDoc.addPage();
        myPage.addText("Mein Geld: "+Testing.geld.ToString(), 0, 0, myDoc.getFontReference("Helvetica"), 20);
        myDoc.addImageReference(Application.dataPath + @"\SaveState\ERDScreenshot.png","Bild");
        myPage.addImage(myDoc.getImageReference("Bild"),400,750);

        //byte[] imageData = System.IO.File.ReadAllBytes("D/forschungsstation_2.PNG");

        //Image myImage = Image.FromFile(@"forschungsstation_2.PNG");
        //pdfPage myPage = myDoc.addPage(myImage.Height, myImage.Width);        
        //myPage.addImage(System.IO.File.ReadAllBytes(imageData), 0, 0, 400, 400);
        //myPage.addImage("D/forschungsstation_2.PNG", 0, 0, 400, 400);

        //myDoc.addImageReference("D/forschungsstation_2.PNG", "Image");

        //System.Drawing.Image img = System.Drawing.Image.FromFile(imagePath);


        myDoc.createPDF( Application.dataPath + @"\PDF\missionsbestätigung.pdf");
        myPage = null;
        myDoc = null; 
    }
}
