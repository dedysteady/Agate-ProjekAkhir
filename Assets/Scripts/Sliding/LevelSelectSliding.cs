using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectSliding : MonoBehaviour
{
    [SerializeField] bool unlocked;
    public Image unlockImage;
    public GameObject[] stars;

    public Sprite starSprite;

    // Start is called before the first frame update
    void Start()
    {

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
        if (PlayerPrefs.GetInt("Sliding Lv" + previousLevelNum) > 0)
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

            for (int i = 0; i < PlayerPrefs.GetInt("Sliding Lv" + gameObject.name); i++)
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
        }
    }
}
