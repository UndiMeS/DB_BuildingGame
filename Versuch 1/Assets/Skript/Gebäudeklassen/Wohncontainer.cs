using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wohncontainer 
{
    private int containernummer;
    private int bettenanzahl;
    private int baukosten;

    public Wohncontainer(int containernummer)
    {
        Containernummer = containernummer;
    }

    public int Containernummer { get => containernummer; set => containernummer = value; }
    public int Bettenanzahl { get => bettenanzahl; set => bettenanzahl = value; }
    public int Baukosten { get => baukosten; set => baukosten = value; }
}
