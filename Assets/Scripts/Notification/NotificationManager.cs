using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Notification") == 1)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NotificationOn()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("Notification", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Notification", 0);
        }

    }
}
