using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenSwap : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F11))
        {
            if(Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Screen.SetResolution(1600, 900, Screen.fullScreenMode);
            } else
            {
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreenMode);
            }
        }
    }


}
