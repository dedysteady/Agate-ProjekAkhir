using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLevelJigsaw : MonoBehaviour
{
    public static SingleLevelJigsaw instance;
    [SerializeField] int currentStarsNum = 0;
    public int _starsNum;
    public int levelIndex;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStar()
    {
        currentStarsNum = _starsNum;

        if (currentStarsNum > PlayerPrefs.GetInt("Jigsaw Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Jigsaw Lv" + levelIndex, _starsNum);
        }

        Debug.Log(PlayerPrefs.GetInt("Jigsaw Lv" + levelIndex, _starsNum));
    }

    public void TimeStar(int star)
    {
        switch (star)
        {
            case 1:
                _starsNum = 3;
                break;

            case 2:
                _starsNum = 2;
                break;

            case 3:
                _starsNum = 1;
                break;

            case 4:
                _starsNum = 0;
                break;
        }
    }
}
