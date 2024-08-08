using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    public void QuitButton()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Area 1");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
}