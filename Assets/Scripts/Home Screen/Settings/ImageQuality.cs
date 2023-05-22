using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ImageQuality : MonoBehaviour
{
    [SerializeField] public static ImageQuality imageQuality;

    [SerializeField] TMP_Dropdown tMP_DropdownImageQuality;
    [SerializeField] int quality;

    // Start is called before the first frame update
    void Start()
    {
        if (imageQuality == null)
        {
            imageQuality = this;
        }

        quality = PlayerPrefs.GetInt("QualityNumber", 3);
        tMP_DropdownImageQuality.value = quality;
        SettingQuality();
    }

    public void SettingQuality()
    {
        QualitySettings.SetQualityLevel(tMP_DropdownImageQuality.value);
        PlayerPrefs.SetInt("QualityNumber", tMP_DropdownImageQuality.value);
        quality = tMP_DropdownImageQuality.value;
    }

    public void ChangerImageQualityForKey()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            tMP_DropdownImageQuality.value++;
            SettingQuality();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            tMP_DropdownImageQuality.value--;
            SettingQuality();
        }
    }
}

