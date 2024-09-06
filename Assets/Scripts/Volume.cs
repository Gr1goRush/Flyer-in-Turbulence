using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button VolumeButton,VibrButton;
    [SerializeField] AudioSource audio;
    [SerializeField] Sprite Onn, Off;
    bool on;
    int vib;
    void Start()
    {
        on = PlayerPrefs.GetInt("vol") == 1 ? true : false;
        vib = PlayerPrefs.GetInt("vib");
        // SwitchVolumeButton();
        if (on)
        {
            audio.volume = 1;
            VolumeButton.GetComponent<Image>().sprite = Onn;
           
        }
        else
        {
            audio.volume = 0;
            VolumeButton.GetComponent<Image>().sprite = Off;
            
        }
        if (vib == 1)
        {
           
            VibrButton.GetComponent<Image>().sprite = Onn;
        }
        else
        {
            
            VibrButton.GetComponent<Image>().sprite = Off;
        }

    }

    public void SwitchVolumeButton()
    {
  
        if (on)
        {
            audio.volume = 0;
            VolumeButton.GetComponent<Image>().sprite = Off;
            on = !on;
        }
        else
        {
            audio.volume = 1;
            VolumeButton.GetComponent<Image>().sprite = Onn;
            on = !on;
        }
        PlayerPrefs.SetInt("vol", on ? 1 : 0);
    }
    public void SwitchVibrationButton()
    {

        if (vib == 1)
        {
            vib = 0;
            VibrButton.GetComponent<Image>().sprite = Off;
        }
        else
        {
            vib = 1;
            VibrButton.GetComponent<Image>().sprite = Onn;
        }
        PlayerPrefs.SetInt("vib", vib);

    }
}
