using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreenToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen is: " +  isFullscreen);
    }
}
