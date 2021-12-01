using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool timeActive = false;
    public float currentTime;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        timeActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeActive == true)
        {
            currentTime += Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeText.text = time.ToString(@"mm\:ss");
    }

    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }

}
