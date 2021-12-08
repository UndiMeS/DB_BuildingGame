using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeschafft : MonoBehaviour
{
    private Vector3 from = new Vector3(-1220, 14, 0);
    private Vector3 to = new Vector3(1220, 304, 0);
    private float time=3;
    private bool temp=true;

    public void Update()
    {
        if (temp)
        {
            gameObject.transform.localPosition = from;
        }
    }

    public void MoveRechtsLinks()
    {
        Invoke("back", time+1);
        temp = false;
        gameObject.LeanMoveX(to.x, time);
    }
    public void back()
    {
        temp = true;
        gameObject.transform.position = from;
    }
}
