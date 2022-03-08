using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entf : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            b.onClick.Invoke();
        }
    }
}
