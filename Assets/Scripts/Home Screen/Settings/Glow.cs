using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Glow : MonoBehaviour
{
    [SerializeField] public static Glow glow;

    [SerializeField] Slider sliderGlow;
    [SerializeField] float sliderValue;
    [SerializeField] Image[] imagesGlow;

    // Start is called before the first frame update
    void Start()
    {
        if (glow == null)
        {
            glow = this;
        }

        sliderGlow.value = PlayerPrefs.GetFloat("Brightness", 0);
        imagesGlow[0].color = new Color(255, 255, 255, sliderGlow.value);
    }

    public void ChangerGlow(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("Brightness", sliderValue);
        imagesGlow[0].color = new Color(255, 255, 255, sliderGlow.value);
    }

    public void ChangerGlowForKey()
    {
        if(Input.GetKey(KeyCode.D))
        {
            sliderGlow.value += 1 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sliderGlow.value -= 1 * Time.deltaTime;
        }
    }
}
