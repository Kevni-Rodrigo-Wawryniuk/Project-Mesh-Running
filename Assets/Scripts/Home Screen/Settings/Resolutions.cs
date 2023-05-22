using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Resolutions : MonoBehaviour
{
    [SerializeField] public static Resolutions resolutions;

    [SerializeField] TMP_Dropdown tmP_DropdownResolutions;
    [SerializeField] Resolution[] resolution1;

    // Start is called before the first frame update
    void Start()
    {
        if (resolutions == null)
        {
            resolutions = this;
        }

        CheckedResolutions();
    }

    public void CheckedResolutions()
    {
        resolution1 = Screen.resolutions;
        tmP_DropdownResolutions.ClearOptions();
        List<string> options = new List<string>();
        int currentsResolution0 = 0;

        for (int i = 0; i < resolution1.Length; i++)
        {
            string options0 = resolution1[i].width + "x" + resolution1[i].height;
            options.Add(options0);

            if (Screen.fullScreen && resolution1[i].width == Screen.currentResolution.width && resolution1[i].height == Screen.currentResolution.height)
            {
                currentsResolution0 = i;
            }
        }

        tmP_DropdownResolutions.AddOptions(options);
        tmP_DropdownResolutions.value = currentsResolution0;
        tmP_DropdownResolutions.RefreshShownValue();

    }

    public void ChangerResolutions(int value)
    {
        Resolution resolution0 = resolution1[value];
        Screen.SetResolution(resolution0.width, resolution0.height, Screen.fullScreen);
    }

    public void ChangerResolutionForTheKey()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            tmP_DropdownResolutions.value++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            tmP_DropdownResolutions.value--;
        }
    }
}
