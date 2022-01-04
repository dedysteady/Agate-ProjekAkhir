using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectJigsaw : MonoBehaviour
{
    [SerializeField] bool unlocked;
    public Image unlockImage;
    public GameObject[] stars;

    public Sprite starSprite;

    public int addHint;
    int currentHint;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hint"))
        {
            currentHint = PlayerPrefs.GetInt("Hint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    void UpdateLevelStatus()
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if(PlayerPrefs.GetInt("Jigsaw Lv" + previousLevelNum) > 0)
        {
            unlocked = true;
        }
    }

    void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for(int i = 0; i < PlayerPrefs.GetInt("Jigsaw Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }

    public void LoadScene(string scene)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(scene);

            if(PlayerPrefs.GetInt("Jigsaw Hint" + gameObject.name) == 1)
            {
                Debug.Log("you've got a hint");
            }
            else
            {
                AddHint();
            }
        }
    }

    public void AddHint()
    {
        currentHint += addHint;
        PlayerPrefs.SetInt("Hint", currentHint);
        PlayerPrefs.SetInt("Jigsaw Hint" + gameObject.name, 1);
    }
}
