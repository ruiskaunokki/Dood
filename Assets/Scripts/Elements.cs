using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elements : MonoBehaviour
{
    public Button UltButton;
    public Text UltName;
    int Elem1;
    int Elem2;
    int UltType;
    string[,] Comb = {{"Огонь", "Пар", "Булыжник", "Огн. смерч"}, 
    {"Пар", "Вода", "Грязь", "Водяной шар"}, 
    {"Булыжник", "Грязь", "Земля", "Кам. дождь"}, 
    {"Огн. смерч", "Водяной шар", "Кам. дождь", "Воздух"}};

    public void InputElem1(int value)
    {
        Elem1 = value;
    }

    public void InputElem2(int value)
    {
        Elem2 = value;
    }
    
    public void Update()
    {
        UltName.text = Comb[Elem1, Elem2];
    }
}
