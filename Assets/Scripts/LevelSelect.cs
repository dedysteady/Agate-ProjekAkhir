using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public GameObject[] stars;

    public Sprite starSprite;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else //if unlock is true, level can play
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for(int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }

    void UpdateLevelStatus()
    {
        int PreviousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + PreviousLevelNum) > 0)
        {
            unlocked = true;
        }
    }

    public void SelectLevel(string _levelName)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_levelName);
        }
    }
}
