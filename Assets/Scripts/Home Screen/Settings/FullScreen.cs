using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    [SerializeField] public static FullScreen fullScreen;

    [SerializeField] Toggle toggleFullScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (fullScreen == null)
        {
            fullScreen = this;
        }

        if (Screen.fullScreen)
        {
            toggleFullScreen.isOn = true;
        }
        else
        {
            toggleFullScreen.isOn = false;
        }
    }

    public void FullScreenIsON(bool IsOnOrNot)
    {
        Screen.fullScreen = IsOnOrNot;
    }

   public void ChangerFullScreenForKey()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Screen.fullScreen = !Screen.fullScreen;

            toggleFullScreen.isOn = !toggleFullScreen.isOn;
        }
    }
}
