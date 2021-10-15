using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().overrideSorting = true;
        this.gameObject.GetComponent<Canvas>().sortingOrder = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
