using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winCondition, pausemenu, info, puzzle;

    public TimeManager timeManager;
    public HintManager hintManager;

    public GameObject star1, star2, star3;

    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
        Time.timeScale = 1f;
    }

    public void WinCondition()
    {
        puzzle.SetActive(false);
        info.SetActive(true);
        winCondition.SetActive(false);
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseMenu()
    {        
        if (isPaused)
        {
            isPaused = false; 
            puzzle.SetActive(true);
            pausemenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true; 
            puzzle.SetActive(false);
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void TimeStarJigsaw()
    {
        if (SceneManager.GetActiveScene().name == "Level 1 Jigsaw" || SceneManager.GetActiveScene().name == "Level 2 Jigsaw")
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            SingleLevelJigsaw.instance.TimeStar(1);
        }

        else if (SceneManager.GetActiveScene().name == "Level 3 Jigsaw" || SceneManager.GetActiveScene().name == "Level 4 Jigsaw")
        {
            if (timeManager.currentTime < 120f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                SingleLevelJigsaw.instance.TimeStar(1);
            }
            else if (timeManager.currentTime >= 120f && timeManager.currentTime < 240f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
                SingleLevelJigsaw.instance.TimeStar(2);
            }
            else if(timeManager.currentTime >= 240f && timeManager.currentTime < 300f)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelJigsaw.instance.TimeStar(3);
            }
            else if (timeManager.currentTime >= 300f)
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelJigsaw.instance.TimeStar(4);
            }
        }

        else if (SceneManager.GetActiveScene().name == "Level 5 Jigsaw")
        {
            if (timeManager.currentTime < 300f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                SingleLevelJigsaw.instance.TimeStar(1);
            }
            else if (timeManager.currentTime >= 300f && timeManager.currentTime < 480f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
                SingleLevelJigsaw.instance.TimeStar(2);
            }
            else if (timeManager.currentTime >= 480f && timeManager.currentTime < 600f)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelJigsaw.instance.TimeStar(3);
            }
            else if (timeManager.currentTime >= 600f)
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelJigsaw.instance.TimeStar(4);
            }
        }
        
    }

    public void TimeStarSliding()
    {
        if (SceneManager.GetActiveScene().name == "Level 1 Sliding" || SceneManager.GetActiveScene().name == "Level 2 Sliding")
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            SingleLevelSliding.instance.TimeStar(1);
        }

        else if (SceneManager.GetActiveScene().name == "Level 3 Sliding" || SceneManager.GetActiveScene().name == "Level 4 Sliding")
        {
            if (timeManager.currentTime < 300f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                SingleLevelSliding.instance.TimeStar(1);
            }
            else if (timeManager.currentTime >= 300f && timeManager.currentTime < 480f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
                SingleLevelSliding.instance.TimeStar(2);
            }
            else if (timeManager.currentTime >= 480f && timeManager.currentTime < 600f)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelSliding.instance.TimeStar(3);
            }
            else if (timeManager.currentTime >= 600f)
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelSliding.instance.TimeStar(4);
            }
        }

        else if (SceneManager.GetActiveScene().name == "Level 5 Sliding")
        {
            if (timeManager.currentTime < 540f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                SingleLevelSliding.instance.TimeStar(1);
            }
            else if (timeManager.currentTime >= 540f && timeManager.currentTime < 720f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
                SingleLevelSliding.instance.TimeStar(2);
            }
            else if (timeManager.currentTime >= 720f && timeManager.currentTime < 900f)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelSliding.instance.TimeStar(3);
            }
            else if (timeManager.currentTime >= 900f)
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                SingleLevelSliding.instance.TimeStar(4);
            }
        }

    }

    
}
