using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GebäudeAnimation : MonoBehaviour
{

    public Animator LandingAnimation;
    public Animator ParachuteAnimation;
    public GameObject GebäudeAnzeige;
    public GameObject Parachute;
    public bool AnimationEndet = false;

    public bool GebäudeBauen;
    // Start is called before the first frame update
    void Start()
    {
        //Animation LandAnim = LandingAnimation["LandingAnmiation"];
        AnimationEndet = false;
        ResetBeschreibungPosition.ERButtonClick = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(AnimationEndet == true)
        {
            LandingAnimation.enabled = false;
        }
        

        
        if(LandingAnimation.isActiveAndEnabled&&LandingAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    ParachuteAnimation.enabled = true;
                   // Debug.Log("not playing");
                    ParachuteAnimation.SetBool("DriveIn", true);

                    //ParachuteAnimation.SetBool("DriveIn", false);
                    
                    //GebäudeAnzeige.SetActive(true);
                }                    
                else
                {
            
        }
       

                if (ParachuteAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    ParachuteAnimation.enabled = false;
                    Parachute.SetActive(false);
                    LandingAnimation.enabled = false;
                    ParachuteAnimation.SetBool("DriveIn", false);
                    
                    GebäudeAnzeige.SetActive(true);

                    
                }    
                else
                {       
            
                    if(ResetBeschreibungPosition.ERButtonClick == true && AnimationEndet == false)
                        {
                            
                            LandingAnimation.Play("LandingAnimation",0,1);
                            LandingAnimation.Play("Idle",0,1);
                            LandingAnimation.enabled = true;
                            
                            Parachute.SetActive(false);
                            GebäudeAnzeige.SetActive(true);
                            Debug.Log("stop animation");

                            AnimationEndet = true;
                            ResetBeschreibungPosition.ERButtonClick = false;
                            
                        }
                        else{
                                
                        }
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
