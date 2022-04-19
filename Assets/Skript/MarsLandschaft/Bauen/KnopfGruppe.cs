using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnopfGruppe : MonoBehaviour
{
    public List<PanelKnopf> panelknoepfe;

    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;

    public PanelKnopf selected;

    public void Subscribe(PanelKnopf knopf)
    {
        if (panelknoepfe == null)
        {
            panelknoepfe = new List<PanelKnopf>();
        }
        panelknoepfe.Add(knopf);
    }

    public void OnTabEnter(PanelKnopf knopf)
    {
        ResetTabs();
        knopf.hintergrund.color = tabHover;
        Testing.NeuesGebaeude = true;
    }

    public void OnTabExit()
    {
        ResetTabs();
        Testing.NeuesGebaeude = false;
    }
    public void OnTabSelected(PanelKnopf knopf)
    {
        selected = knopf;
        ResetTabs();
        knopf.hintergrund.color = tabActive;
    }

    public void ResetTabs()
    {
        foreach(PanelKnopf knopf in panelknoepfe)
        {
           knopf.hintergrund.color = tabIdle;
           
        }
    }
}
