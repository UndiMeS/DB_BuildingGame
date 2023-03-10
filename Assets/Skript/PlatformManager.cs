using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    public GameObject LetterBoxUp;
    public GameObject LetterBoxDown;
    public LetterBoxer letterbox;
    public RectTransform LandschaftCanvas;

    void Awake()
    {
        #if UNITY_IOS
        LetterBoxDown.SetActive(false);
        LetterBoxUp.SetActive(false);
        letterbox.onAwake = false;



        //LandschaftCanvas.sizeDelta = new Vector3 (1600.0f, 1200.0f, 0.0f);

        #endif
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}