using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeisteBottom : MonoBehaviour
{
    public static GameObject leiste_bottom;

    public Sprite schwacheEntitaet;
    public Sprite selecSchwacheEntitaet;
    public Sprite entitaet;
    public Sprite selecEntitaet;
    public Toggle schwEntKnopf;
    public GameObject dropdownSE;
    public GameObject prefabBez;

    public GameObject erFlaeche;

    public GameObject bezEinstellung;
    public static TMPro.TMP_Dropdown objekt1;
    public static TMPro.TMP_Dropdown objekt2;
    public  TMPro.TMP_Dropdown kard1;
    public TMPro.TMP_Dropdown kard2;
    public Toggle primKnopf;

    public void Awake()
    {
       leiste_bottom = gameObject;
       objekt1= bezEinstellung.transform.GetChild(1).gameObject.GetComponent<TMPro.TMP_Dropdown>();
       objekt2= bezEinstellung.transform.GetChild(4).gameObject.GetComponent<TMPro.TMP_Dropdown>();

    }

    public void Update()
    {
        if (ERErstellung.selectedGameObjekt!=null&&ERErstellung.selectedGameObjekt.CompareTag("Entitaet"))
        {
            if (ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach)
            {
                schwEntKnopf.SetIsOnWithoutNotify(true);
                dropdownSE.SetActive(true);
                objekt1.SetValueWithoutNotify(schwachEntityZuNummer(ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet));
            }
            else
            {
                schwEntKnopf.SetIsOnWithoutNotify(false) ;
                dropdownSE.SetActive(false);
            }
        }
        if (ERErstellung.selectedGameObjekt != null && ERErstellung.selectedGameObjekt.CompareTag("Attribut"))
        {
            if (ERErstellung.selectedGameObjekt.GetComponent<Attribut>().primaerschluessel)
            {
                primKnopf.SetIsOnWithoutNotify(true);
            }
            else
            {
                primKnopf.SetIsOnWithoutNotify(false);
            }
        }
        if (ERErstellung.selectedGameObjekt != null && ERErstellung.selectedGameObjekt.CompareTag("Beziehung"))
        {         
            if (ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().kard2.Equals("")) { }
            else if (ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().kard2.Equals("1"))
            {
                kard2.value = 0;
            }
            else
            {
                kard2.value = 1;
            }

            if (ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().kard1.Equals("")) { }
            else if (ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().kard1.Equals("1"))
            {
                kard1.value = 0;
            }
            else
            {
                kard1.value = 1;
            }
                            if (entityZuNummer(ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().objekt1) != -1)
                {
                    objekt1.SetValueWithoutNotify( entityZuNummer(ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().objekt1));
                }

                if (entityZuNummer(ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().objekt2) != -1)
                {
                    objekt2.SetValueWithoutNotify( entityZuNummer(ERErstellung.selectedGameObjekt.GetComponent<Beziehung>().objekt2));
                }
                
                
                
             
            
        }

    }

    public void SchwacheEntitaet(bool state)
    {
        if (ERErstellung.selectedGameObjekt == null||ERErstellung.modellObjekte.Count==1)
        {
            return;
        }
        if (ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt))
        {
            schwEntKnopf.isOn = ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach;
            FehlerAnzeige.fehlertext = "Kann nicht verändert werden.";
            return;
        }
        if (state)
        {
            int anz = 0;
            foreach (GameObject ent in ERErstellung.modellObjekte)
            {
                if (ent.CompareTag("Entitaet"))
                {
                    anz++;
                }
            }
            if (anz < 2)
            {
                
                FehlerAnzeige.fehlertext = "Man braucht mindestens 2 Entitäten.";
                schwEntKnopf.SetIsOnWithoutNotify(false);
                return;
            }
            foreach (GameObject bez in ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().beziehungen)
            {
                if (bez == null)
                {
                    ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().beziehungen.Remove(bez);
                    SchwacheEntitaet(true);
                    return;
                }
                if (bez.GetComponent<Beziehung>().schwach)
                {
                    schwEntKnopf.isOn = false;
                    FehlerAnzeige.fehlertext = "Das ist nicht möglich";
                    return;
                }
            }
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().originalSprite = schwacheEntitaet;
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().selectedSprite = selecSchwacheEntitaet;
            dropdownSE.GetComponent<TMPro.TMP_Dropdown>().RefreshShownValue();
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach = true;
            SchwacheEntitaetAuswahl(0);
            
        }
        else
        {
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().originalSprite = entitaet;
            ERErstellung.selectedGameObjekt.GetComponent<ERObjekt>().selectedSprite = selecEntitaet;
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach = false;
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().beziehungen.Remove(ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung.GetComponent<Beziehung>().objekt2.GetComponent<Entitaet>().beziehungen.Remove(ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
            Destroy(ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
            ERErstellung.modellObjekte.Remove(ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung);
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet = null;
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung = null;
        }
    }

    public void SchwacheEntitaetAuswahl(int option)
    {
        dropdownSE.GetComponent<TMPro.TMP_Dropdown>().RefreshShownValue();
        GameObject entity = null;
        int z = 0;
        int vater = -1;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (z == option&&!obj.GetComponent<Entitaet>().schwach)
                {
                    entity = obj;
                }
                
                if (ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet!= null &&ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet.Equals(obj))
                {
                    vater = z;
                }
                if (!ERErstellung.selectedGameObjekt.Equals(obj))
                {
                    z++;
                }               
            }
        }
        if (ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt))
        {
            if (vater != -1)
            {
                dropdownSE.GetComponent<TMPro.TMP_Dropdown>().value = vater;
            }
            else
            {
                Debug.Log("Bug");
            }
            FehlerAnzeige.fehlertext = "Kann nicht verändert werden.";
            return;
        }
        if (entity != null && !entity.Equals(ERErstellung.selectedGameObjekt))
        {
            GameObject bez = null;
            if (ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet == null)
            {
                gameObject.GetComponent<ERErstellung>().erstelleObjekt(prefabBez);
                bez = ERErstellung.selectedGameObjekt;
                ERErstellung.schwach = true;
                ERErstellung.changeSelectedGameobjekt(ERErstellung.lastselected);
                ERErstellung.schwach = false;


                ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach = false;
                bez.GetComponent<Beziehung>().welcheEntity(1, entityZuNummer(ERErstellung.selectedGameObjekt), false) ;
                ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwach = true;
                bez.GetComponent<Beziehung>().schwach = true;
                ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung = bez;
                

            }
            

            bez = ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung;
            
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().vaterEntitaet = entity;            
            ERErstellung.selectedGameObjekt.GetComponent<Entitaet>().schwacheBeziehung = ERErstellung.lastselected;
            
            if (bez.GetComponent<Beziehung>() != null)
            {
                bez.GetComponent<Beziehung>().welcheEntity(2, option,true);
                bez.GetComponent<Beziehung>().objekt1 = ERErstellung.selectedGameObjekt;
                bez.GetComponent<Beziehung>().objekt2 = entity;
                
            }
            else
            {
                Debug.Log(bez.name);
            }
           

        }
        else
        {
            FehlerAnzeige.fehlertext = "Es kann keine schwache Entität zu sich selber erstellt werden";
        }
    }
    private int schwachEntityZuNummer(GameObject ent)
    {
        int z = 0;
        if (ent == null)
        {
            return -1;
        }
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (ent.GetComponent<Entitaet>().schwach && ERErstellung.selectedGameObjekt.Equals(obj))
                {
                    z--;
                }
                if (obj == null)
                {
                    ERErstellung.modellObjekte.Remove(obj);
                    return entityZuNummer(ent);
                }
                if (ent.Equals(obj))
                {
                    return z;
                }
                z++;
            }
        }
        return -1;
    }
    private int entityZuNummer(GameObject ent)
    {       
        int z = 0;
        if (ent == null)
        {
            return -1;
        }
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (obj == null)
                {
                    ERErstellung.modellObjekte.Remove(obj);
                    return entityZuNummer(ent);
                }
                if (ent.Equals(obj))
                {
                    return z;
                }
                z++;
            }
        }
        return -1;
    }

    public static void setValueDropDown(GameObject ent, int einsOderZwei)
    {
        int entnummer = -1;
        int z = 0;
        int partner = -1;
        foreach (GameObject obj in ERErstellung.modellObjekte)
        {
            if (obj.CompareTag("Entitaet"))
            {
                if (ent.Equals(obj))
                {
                    entnummer = z;
                }
                z++;
            }
        }
        if (ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt))
        {
            if (partner != -1)
            {
                if (einsOderZwei == 1)
                {
                    objekt1.GetComponent<TMPro.TMP_Dropdown>().value = partner;
                }
                else
                {
                    objekt2.GetComponent<TMPro.TMP_Dropdown>().value = partner;
                }
            }
            else
            {
                Debug.Log("Bug");
            }
            FehlerAnzeige.fehlertext = "Kann nicht verändert werden.";
            return;
        }
        if (einsOderZwei == 1&&entnummer!=-1)
        {
            objekt1.value = z;
        }else if(einsOderZwei == 2 && entnummer != -1)
        {
            objekt2.value = z;
        }
    }

    public void primaerschluessel(bool state)
    {
        if (ERErstellung.selectedGameObjekt == null)
        {
            return;
        }
        if (ERAufgabe.gespeicherteObjekte.Contains(ERErstellung.selectedGameObjekt))
        {
            primKnopf.isOn = ERErstellung.selectedGameObjekt.GetComponent<Attribut>().primaerschluessel;
            FehlerAnzeige.fehlertext = "Kann nicht verändert werden.";
            return;
        }
        if (state)
        {
            ERErstellung.selectedGameObjekt.transform.parent.GetComponent<Entitaet>().primaerschluessel.Add(ERErstellung.selectedGameObjekt);
            ERErstellung.selectedGameObjekt.GetComponent<Attribut>().primaerschluessel = state;
            ERErstellung.selectedGameObjekt.transform.GetChild(1).GetChild(2).transform.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline;
        }
        else
        {
            ERErstellung.selectedGameObjekt.GetComponent<Attribut>().primaerschluessel = state;
            ERErstellung.selectedGameObjekt.transform.GetChild(1).GetChild(2).transform.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Normal;
            ERErstellung.selectedGameObjekt.transform.parent.GetComponent<Entitaet>().primaerschluessel.Remove(ERErstellung.selectedGameObjekt);
        }
    }
}
