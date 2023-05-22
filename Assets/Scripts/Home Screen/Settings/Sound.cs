using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Sound : MonoBehaviour
{
    [SerializeField] public static Sound sound;

    [SerializeField] Slider sliderSound;
    [SerializeField] float sliderValue;
    [SerializeField] Image[] muteImage;

    // Start is called before the first frame update
    void Start()
    {
        if (sound == null)
        {
            sound = this;
        }

        sliderSound.value = PlayerPrefs.GetFloat("Volume", 0);
        AudioListener.volume = sliderSound.value;
        CheckMute();
    }

    public void ChangerSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("Volume", sliderValue);
        AudioListener.volume = sliderSound.value;
        CheckMute();
    }
    public void CheckMute()
    {
        if (sliderSound.value == 0)
        {
            muteImage[0].enabled = true;
            muteImage[1].enabled = true;
        }
        else
        {
            muteImage[0].enabled = false;
            muteImage[1].enabled = false;
        }
    }

    public void ChangerSliderForKey()
    {

        if (Input.GetKey(KeyCode.D))
        {
            sliderSound.value += 0.5f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sliderSound.value -= 0.5f * Time.deltaTime;
        }
    }
}
