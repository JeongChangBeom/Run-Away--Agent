using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        if (this.gameObject.name == "BgmSlider")
        {
            GameObject.Find("Canvas").transform.Find("Option/BgmSlider").GetComponent<Slider>().value = SoundManager.instance.bgmVolume;
        }

        if (this.gameObject.name == "SfxSlider")
        {
            GameObject.Find("Canvas").transform.Find("Option/SfxSlider").GetComponent<Slider>().value = SoundManager.instance.sfxVolume;
        }
    }
    public void SetLevel(float sliderVal)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderVal) * 20);

        if (this.gameObject.name == "BgmSlider")
        {
            SoundManager.instance.bgmVolume = sliderVal;
        }

        if (this.gameObject.name == "SfxSlider")
        {
            SoundManager.instance.sfxVolume = sliderVal;
        }
    }

}
