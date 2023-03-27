using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    public GameObject LetterBoxUp;
    public GameObject LetterBoxDown;
    public LetterBoxer letterbox;
    public RectTransform LandschaftCanvas;
    public RTS_Cam.RTS_Camera CameraScript;

    public static bool touch;

    void OnEnable()
    {
        TouchSimulation.Enable();
        //PlayerInput.SwitchCurrentControlScheme(InputSystem.devices.First(d => d == Touchscreen.current));
    }


    void Awake()
    {



        #if UNITY_IOS
        touch = true;
        LetterBoxDown.SetActive(false);
        LetterBoxUp.SetActive(false);
        letterbox.onAwake = false;

        CameraScript.useTouchInput = true;
        CameraScript.usePanning = false;
        //LandschaftCanvas.sizeDelta = new Vector3 (1600.0f, 1200.0f, 0.0f);
        #endif

        #if Unity_STANDALONE

        touch = false;

        CameraScript.useTouchInput = false;
        CameraScript.usePanning = true;

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