using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GebäudeAnimation : MonoBehaviour
{

    public Animator LandingAnimation;
    public Animator ParachuteAnimation;
    public GameObject GebäudeAnzeige;
    public GameObject Parachute;

    public bool GebäudeBauen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LandingAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    ParachuteAnimation.enabled = true;
                    Debug.Log("not playing");
                    ParachuteAnimation.SetBool("DriveIn", true);

                    //ParachuteAnimation.SetBool("DriveIn", false);
                    
                    //GebäudeAnzeige.SetActive(true);
                }
                    
                else
                {                   
                    
                }

                if(ParachuteAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    ParachuteAnimation.enabled = false;
                    Parachute.SetActive(false);
                    LandingAnimation.enabled = false;
                    ParachuteAnimation.SetBool("DriveIn", false);
                    GebäudeAnzeige.SetActive(true);
                    
                }
                    
                else
                {                   
                    
                }

                if(GebäudeBauen == true)
                {
                    GebäudeBauen = false;
                    LandingAnimation.enabled = true;
                    Parachute.SetActive(true);

                    LandingAnimation.SetBool("Landing", true);


                    LandingAnimation.SetBool("Landing", false);

                    
                }


                
    }
}
