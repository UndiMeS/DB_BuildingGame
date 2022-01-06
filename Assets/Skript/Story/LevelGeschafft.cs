using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeschafft : MonoBehaviour
{
    private Vector3 from = new Vector3(-1220, 14, 0);
    private Vector3 to = new Vector3(1220, 304, 0);
    private float time=4;
    private bool temp=true;

    private void Start()
    {
        from = gameObject.transform.position;
        to = gameObject.transform.position + new Vector3(Screen.width+gameObject.GetComponent<RectTransform>().sizeDelta.x, 0, 0);
    }

    public void Update()
    {
        if (temp)
        {
            gameObject.transform.position = from;
        }
    }

    public void MoveRechtsLinks()
    {
        Invoke("back", time+1);
        temp = false;
        gameObject.LeanMove(to, time);
    }
    public void back()
    {
        temp = true;
        gameObject.transform.position = from;
    }

        public void LevelUpAnimationStop()
    {
        this.gameObject.SetActive(false);
    }
}
