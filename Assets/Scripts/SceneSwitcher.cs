using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToLevel0()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchToLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void SwitchToLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public static void SwitchToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
