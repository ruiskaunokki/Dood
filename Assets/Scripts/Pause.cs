using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject AllUI;
    public GameObject PauseUI;
    public GameObject WinUI;

    void Start() {
        AllUI.SetActive(true);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);
    }

    public void PressPause()
    {
        AllUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PressGoBack()
    {
        AllUI.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PressRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AllUI.SetActive(true);
        PauseUI.SetActive(false);
        WinUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PressExit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
