using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//https://www.google.com/search?q=unity+draw+rounded+edge+rectangle&biw=1920&bih=937&sxsrf=AOaemvLk2IQPGT5vTU9dPXKmOAhqSqR8Wg%3A1634819644961&ei=PF5xYcH8Of6Txc8Pld6E6Ao&oq=unity+draw+rounded+edge+rectangle&gs_lcp=Cgdnd3Mtd2l6EAMYADIICCEQFhAdEB4yCAghEBYQHRAeMggIIRAWEB0QHjoHCAAQRxCwAzoECCMQJzoFCCEQoAFKBAhBGABQ6BxYwi9g8TVoBnAAeACAAYYBiAHLBpIBAzguMZgBAKABAcgBCMABAQ&sclient=gws-wiz#kpvalbx=_S15xYZLAPIyXxc8Pg6646Ao17
public class HighlightButton : MonoBehaviour
{
    public Image image;

    public void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void Update()
    {
        if (gameObject.activeSelf)
        {
            if (((int)Time.time) % 3 == 0)
            {
                image.CrossFadeAlpha(1f, 1, true);
            }
            else if(((int)(Time.time+1.5)) % 3 == 0)
            {
                image.CrossFadeAlpha(0f, 1, true);
            }
        }
        else
        {
            
        }
    }
}