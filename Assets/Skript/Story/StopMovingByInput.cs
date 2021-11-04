using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovingByInput : MonoBehaviour
{
    public void input(string str)
    {
        Camera.main.GetComponent<RTS_Cam.RTS_Camera>().useKeyboardInput = false;
        Invoke("KeyboardMoveOn", 2);
    }
    public void KeyboardMoveOn()
    {
        Camera.main.GetComponent<RTS_Cam.RTS_Camera>().useKeyboardInput = true;
    }


}
