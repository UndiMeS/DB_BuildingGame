using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraBewegung : MonoBehaviour
{
    public Camera kamera;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        int KameraX = Testing.weite / 2 * Testing.zellengroesse;
        int KameraY = Testing.hoehe / 2 * Testing.zellengroesse;
        int KameraZ = -1 * Mathf.Max(Testing.hoehe, Testing.weite) / 2 * Testing.zellengroesse;

        gameObject.transform.Translate(KameraX, KameraY, KameraZ);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bewegung = Movement();
        kamera.transform.Translate(bewegung);
     }

    private Vector3 Movement()
    {
        //Bewegung aus Tatsenbewegung
        Vector3 bewegVektor = Vector3.zero;
        bewegVektor += transform.up * Input.GetAxis("Vertical");
        bewegVektor += transform.right * Input.GetAxis("Horizontal");
        bewegVektor += transform.forward *Input.mouseScrollDelta.y*5;
        bewegVektor *= speed;
        
        //Grenzen
        if ((kamera.transform.position.x < (-kamera.transform.position.z-1) && bewegVektor.x < 0)
            || (kamera.transform.position.x > (0.3*kamera.transform.position.z +210) && bewegVektor.x>0))
        {           
            bewegVektor.x = 0;
        }

        if ((kamera.transform.position.y < (-.2 * kamera.transform.position.z -1.7) && bewegVektor.y < 0)
            || (kamera.transform.position.y > (0.6 * kamera.transform.position.z +140) && bewegVektor.y > 0))
        {
            bewegVektor.y = 0;
        }

        if ((kamera.transform.position.z > Testing.zellengroesse * (-2) && bewegVektor.z >0)
            || (kamera.transform.position.z<-(Mathf.Min(Testing.weite, Testing.hoehe)+2)*Testing.zellengroesse && bewegVektor.z < 0))
        {
            bewegVektor.z = 0;
        }

        return bewegVektor;
    }
}
