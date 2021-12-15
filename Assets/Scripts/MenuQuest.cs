using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuQuest : MonoBehaviour
{
    public QuestManager[] questManagers; 
    public GameObject[] lockImages;
    public Text[] texts;

    public int jigsawLevel, slidingLevel, HintUse, BuyHint;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("jigsawLevel"))
        {
            jigsawLevel = PlayerPrefs.GetInt("jigsawLevel");
        }
        if (PlayerPrefs.HasKey("slidingLevel"))
        {
            slidingLevel = PlayerPrefs.GetInt("slidingLevel");
        }
        if (PlayerPrefs.HasKey("HintUse"))
        {
            HintUse = PlayerPrefs.GetInt("HintUse");
        }
        if (PlayerPrefs.HasKey("BuyHint"))
        {
            BuyHint = PlayerPrefs.GetInt("BuyHint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        QuestHistory();
    }

    void QuestHistory()
    {
        if (PlayerPrefs.GetInt("HintUse") >= 10)
        {
            lockImages[2].SetActive(false);
            questManagers[2].unlocked = true;
            texts[2].text = HintUse.ToString() + "/ 10";
        }
        if (PlayerPrefs.GetInt("BuyHint") >= 5)
        {
            lockImages[4].SetActive(false);
            questManagers[4].unlocked = true;
            texts[4].text = BuyHint.ToString() + "/ 5";
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
