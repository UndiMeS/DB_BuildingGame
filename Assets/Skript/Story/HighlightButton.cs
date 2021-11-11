using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//https://www.google.com/search?q=unity+draw+rounded+edge+rectangle&biw=1920&bih=937&sxsrf=AOaemvLk2IQPGT5vTU9dPXKmOAhqSqR8Wg%3A1634819644961&ei=PF5xYcH8Of6Txc8Pld6E6Ao&oq=unity+draw+rounded+edge+rectangle&gs_lcp=Cgdnd3Mtd2l6EAMYADIICCEQFhAdEB4yCAghEBYQHRAeMggIIRAWEB0QHjoHCAAQRxCwAzoECCMQJzoFCCEQoAFKBAhBGABQ6BxYwi9g8TVoBnAAeACAAYYBiAHLBpIBAzguMZgBAKABAcgBCMABAQ&sclient=gws-wiz#kpvalbx=_S15xYZLAPIyXxc8Pg6646Ao17
public class HighlightButton : MonoBehaviour
{
    public bool test;
    public bool highlinghtingOn = false;
    //public Image image;
    private bool einmal = true;

    public Material M_material;
    public Color SelectedColor;
    public Color NotSelectedColor;

    private float schnelligkeit=1.5f;
    void Start()
    {
        if (test)
        {
            M_material = GetComponent<Image>().materialForRendering;

            SelectedColor = M_material.GetColor("_OutlineColor");

            NotSelectedColor = Color.black;
            NotSelectedColor.a = 0;
            //M_material.SetColor("_OutlineColor", new Color32((byte) 0, (byte) 0, (byte) 0, (byte) 0));
        }

    }

    public void FixedUpdate()
    {

        if (test)
        {
            if (highlinghtingOn)
            {
                //aus
                if (((int)Time.time / schnelligkeit) %2 == 0)
                {
                    SelectedColor.a = 2*((Time.time / schnelligkeit) - ((int)Time.time / schnelligkeit));
                   }
                //an
                else if (((int)Time.time / schnelligkeit) % 2 == 1)
                {
                    SelectedColor.a =1- 2*((Time.time / schnelligkeit) - ((int)Time.time / schnelligkeit));
                }
                M_material.SetColor("_OutlineColor",SelectedColor);
                
            }
            else
            {
                //gameObject.GetComponent<Image>().CrossFadeAlpha(0f, 0, true);
                M_material.SetColor("_OutlineColor", NotSelectedColor);
            }
        }
        else
        {

            if (highlinghtingOn)
            {
                if (((int)Time.time / schnelligkeit) % 2 == 0)
                {
                    gameObject.GetComponent<Image>().CrossFadeAlpha(1f, 1, true);
                }
                else if (((int)Time.time / schnelligkeit) % 2 == 1)
                {
                   gameObject.GetComponent<Image>().CrossFadeAlpha(0f, 1, true);
                }
            }
            else
            {
                gameObject.GetComponent<Image>().CrossFadeAlpha(0f, 0, true);
            }
        }
    }
}