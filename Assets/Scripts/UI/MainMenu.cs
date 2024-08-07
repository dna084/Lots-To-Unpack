using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button optionsButton;

    public SceneLoader sceneLoader;
    public void PlayButton()
    {
        sceneLoader.LoadScene("Area 1");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        // Options logic
    }

}
