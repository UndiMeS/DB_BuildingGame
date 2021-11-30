using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeschafft : MonoBehaviour
{
    public Vector3 from = new Vector3(-253, 304, 0);
    public Vector3 to = new Vector3(1220, 304, 0);
    public float time=3;
    private bool temp;

    public void Update()
    {
        if (temp)
        {
            gameObject.transform.position = from;
        }
    }

    public void MoveRechtsLinks()
    {
        gameObject.LeanMoveX(to.x, time);
        Invoke("back", time+1);
        temp = false;
    }
    public void back()
    {
        temp = true;
        gameObject.transform.position = from;
    }
}
