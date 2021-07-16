using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscER : MonoBehaviour
{
    public GameObject button;
    Button b;

    // Start is called before the first frame update
    void Start()
    {
        b = button.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //Öffne ER-Optionemenu bei Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            b.onClick.Invoke();
        }
    }
}
