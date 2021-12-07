using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLevel : MonoBehaviour
{
    [SerializeField] int currentStarsNum = 0;
    public int _starsNum;
    public int levelIndex;

    public TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeStar();
    }

    public void UpdateStar()
    {
        currentStarsNum = _starsNum;

        if(currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        }

        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starsNum));
    }

    void TimeStar()
    {
        if (timeManager.currentTime < 5f)
        {
            _starsNum = 3;
        }
        else if (timeManager.currentTime >= 5f && timeManager.currentTime < 10f)
        {
            _starsNum = 2;
        }
        if (timeManager.currentTime >= 10f)
        {
            _starsNum = 1;
        }
    }
}
