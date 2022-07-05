using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetSpell.SpellChecker;
using static NetSpell.SpellChecker.Spelling;

public class SpellChecking : MonoBehaviour
{
    public static Spelling SpellChecker;
    public static List<string> ueberpruefteWoerterKorrekt= new List<string>();
    public static List<string> ueberpruefteWoerterFalsch = new List<string>();

    public void Awake()
    {
        if (ERAufgabe.zeitZumLoesen == 0)
        {
            SpellChecker = new Spelling();
            rechtschreibPruefer("Test");
        }
    }

    public bool rechtschreibPruefer(string word)
    {
       
        if (ueberpruefteWoerterKorrekt.Contains(word))
        {
            return true;
        }
        else if (ueberpruefteWoerterFalsch.Contains(word))
        {
            return false;
        }
        else
        {
            
            //SpellChecker.Text = word;
            bool temp = true;
            if (word.Contains(" "))
            {
                string[] splited = word.Split(' ');
                foreach (string wordpart in splited)
                {
                    temp &= SpellChecker.TestWord(wordpart);
                    
                }
            }
            else
            {
                temp = SpellChecker.TestWord(word);
            }

            if (temp)
            {
                ueberpruefteWoerterKorrekt.Add(word);
            }
            else
            {
                ueberpruefteWoerterFalsch.Add(word);
            }
            return temp;
        }
    }


}
