using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elements : MonoBehaviour
{
    public Joystick UltJ;
    public GameObject UltImage;
    public GameObject Player;
    public Sprite[] Sprites;
    public GameObject[] Ults;
    Image ElemImage;
    bool itReleased;
    int Elem1;
    int Elem2;
    float cooldown;
    float cdtimer;
    float x;
    float y;
    int[,] Comb = {
        {0, 4, 5, 6}, 
        {4, 1, 7, 8}, 
        {5, 7, 2, 9}, 
        {6, 8, 9, 3}};

    public void InputElem1(int value)
    {
        Elem1 = value;
    }

    public void InputElem2(int value)
    {
        Elem2 = value;
    }
    
    void Start() 
    {
        ElemImage = UltImage.GetComponent<Image>();
        itReleased = false;
        cdtimer = 1.3f;
    }
    
    public void Update()
    {
        if (cdtimer == cooldown)
        {
            switch (Comb[Elem1, Elem2])
            {
                case 0:
                cooldown = 2.6f;
                break;
                case 1: 
                cooldown = 3f;
                break;
                case 2: 
                cooldown = 3.4f;
                break;
                case 3: 
                cooldown = 2f;
                break;
                default:
                cooldown = 0f;
                break;
            }
            cdtimer = cooldown;
            ElemImage.sprite = Sprites[Comb[Elem1, Elem2]];
            Vector3 rotVector = (Vector3.up * UltJ.Horizontal + Vector3.left * UltJ.Vertical);
            if (UltJ.Horizontal != 0 || UltJ.Vertical != 0)
            {
                Player.transform.rotation = Quaternion.LookRotation(Vector3.forward, rotVector);
                itReleased = true;
            }
            if ((UltJ.Horizontal == 0 && UltJ.Vertical == 0) && itReleased)
            {
                Instantiate(Ults[Comb[Elem1, Elem2]], transform.position, transform.rotation);
                itReleased = false;
                cdtimer -= Time.deltaTime;
            }
        }
        else 
        {
            ElemImage.sprite = Sprites[10];
            if (cdtimer <=0)
            {
                cdtimer = cooldown;
            }
            else
            {
                cdtimer -= Time.deltaTime;
            }
        }
    }
}
