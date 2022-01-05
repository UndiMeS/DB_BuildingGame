using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hilfe_Knopf : MonoBehaviour
{
    public List<GameObject> hilfen;
    public static List<GameObject> alle= new List<GameObject>();

    private void Awake()
    {

        foreach(GameObject item in hilfen)
        {
            alle.Add(item);
        }
    }
    public void onClick(){
        foreach (GameObject item in alle)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in hilfen)
        {
            item.SetActive(true);
        }
        Invoke("aus",5);
    }

    public void aus(){
        foreach (GameObject item in hilfen)
        {
            item.SetActive(false);
        }
    }
     private void OnCollisionEnter(Collision other) {
        foreach (GameObject item in alle)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in hilfen)
        {
            item.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision other) {
        foreach (GameObject item in hilfen)
        {
            item.SetActive(false);
        }
    }
}
