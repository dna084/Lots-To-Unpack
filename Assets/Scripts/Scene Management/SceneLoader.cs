using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Button myButton = null;
    public void LoadScene(string sceneName)
    {
        Debug.Log("SceneName: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayButton(string buttonString)
    {
        LoadScene(buttonString);
    }

    public void OptionsMenu()
    {
        //
    }
}