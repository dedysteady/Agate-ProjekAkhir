using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Audio : MonoBehaviour
{
    public Toggle toggleBGM, toggleSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("bgm") == 1)
        {
            toggleBGM.isOn = true;
        }


        if (PlayerPrefs.GetInt("sfx") == 1)
        {
            toggleSFX.isOn = true;
        }
    }

    public void BgmOnOff()
    {
        if (toggleBGM.isOn)
        {
            PlayerPrefs.SetInt("bgm", 1);
        }
        else
        {
            PlayerPrefs.SetInt("bgm", 0);
        }
    }

    public void SfxOnOff()
    {
        if (toggleSFX.isOn)
        {
            PlayerPrefs.SetInt("sfx", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sfx", 0);
        }
    }
}
