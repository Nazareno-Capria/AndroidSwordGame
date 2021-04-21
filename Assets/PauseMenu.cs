using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject UserUI;

    private void Update()
    {
        if (GameIsPaused)
        {

        }
    }

    public void PauseGame()
    {
        GameIsPaused = true;
        UserUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
        FindObjectOfType<LineRenderer>(true).enabled = true;
        UserUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Salgo de la app");
        Application.Quit();
    }

    public void GoToShop()
    {
        Debug.Log("fui a la tienda y volvi xd");
    }
}
