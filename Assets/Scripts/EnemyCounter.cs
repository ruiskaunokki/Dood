using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject AllUI;
    public GameObject WinUI;
    public Text Counter;
    int AliveCount;

    void Start() 
    {
        Counter.text = "Врагов: " + AliveCount;
        AliveCount = 0;
    }

    void LateUpdate()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i] != null)
            {
                AliveCount++;
            }
        }
        if (AliveCount == 0)
        {
            AllUI.SetActive(false);
            WinUI.SetActive(true);
            Time.timeScale = 0f;
        }
        Counter.text = "Врагов: " + AliveCount;
        AliveCount = 0;
    }
}
