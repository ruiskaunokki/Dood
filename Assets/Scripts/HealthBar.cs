using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;
    public GameObject smb;

    public void SetMaxHealth(int hp)
    {
        HealthSlider.maxValue = hp;
        HealthSlider.value = hp;
    }

    public void SetHealth(int hp)
    {
        HealthSlider.value = hp;
    }
}
