using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuQuest : MonoBehaviour
{
    public Button[] button;
    public QuestManager[] questManagers; 
    public GameObject[] lockImages;
    public Text[] texts;

    public int jigsawLevel, slidingLevel, HintUse, BuyHint, stars;

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

        stars = PlayerPrefs.GetInt("Jigsaw Lv" + 1) + PlayerPrefs.GetInt("Jigsaw Lv" + 2) + PlayerPrefs.GetInt("Jigsaw Lv" + 3) + PlayerPrefs.GetInt("Jigsaw Lv" + 4) + PlayerPrefs.GetInt("Jigsaw Lv" + 5) +
            PlayerPrefs.GetInt("Sliding Lv" + 1) + PlayerPrefs.GetInt("Sliding Lv" + 2) + PlayerPrefs.GetInt("Sliding Lv" + 3) + PlayerPrefs.GetInt("Sliding Lv" + 4) + PlayerPrefs.GetInt("Sliding Lv" + 5);
    }

    // Update is called once per frame
    void Update()
    {
        QuestHistory();
        ButtonInteractable();
    }

    void QuestHistory()
    {
        texts[2].text = HintUse.ToString() + "/ 10";
        texts[3].text = stars.ToString() + "/ 15";
        texts[4].text = BuyHint.ToString() + "/ 5";
        if ((PlayerPrefs.GetInt("Jigsaw Lv" + 5) > 2) || (PlayerPrefs.GetInt("Sliding Lv" + 5) > 2))
        {
            lockImages[0].SetActive(false);
            questManagers[0].unlocked = true;
            texts[0].text = "1/1";
        }
        if ((PlayerPrefs.GetInt("Jigsaw Lv" + 45) > 2) || (PlayerPrefs.GetInt("Sliding Lv" + 45) > 2))
        {
            lockImages[1].SetActive(false);
            questManagers[1].unlocked = true;
            texts[1].text = "1/1";
        }
        if (PlayerPrefs.GetInt("HintUse") >= 10)
        {
            lockImages[2].SetActive(false);
            questManagers[2].unlocked = true;
            texts[2].text = "10/10";
        }
        if (stars >= 15)
        {
            lockImages[3].SetActive(false);
            questManagers[3].unlocked = true;
            texts[3].text = "15/15";
        }
        if (PlayerPrefs.GetInt("BuyHint") >= 5)
        {
            lockImages[4].SetActive(false);
            questManagers[4].unlocked = true;
            texts[4].text = "5/5";
        }
    }

    public void HasClaim()
    {
        if (questManagers[0].hasClaim)
        {
            PlayerPrefs.SetInt("hasClaim", 1);
        }
        if (questManagers[1].hasClaim)
        {
            PlayerPrefs.SetInt("hasClaim1", 1);
        }
        if (questManagers[2].hasClaim)
        {
            PlayerPrefs.SetInt("hasClaim2", 1);
        }
        if (questManagers[3].hasClaim)
        {
            PlayerPrefs.SetInt("hasClaim3", 1);
        }
        if (questManagers[4].hasClaim)
        {
            PlayerPrefs.SetInt("hasClaim4", 1);
        }
    }

    void ButtonInteractable()
    {
        if (PlayerPrefs.GetInt("hasClaim") == 1)
        {
            button[0].interactable = false;
        }
        if (PlayerPrefs.GetInt("hasClaim1") == 1)
        {
            button[1].interactable = false;
        }
        if (PlayerPrefs.GetInt("hasClaim2") == 1)
        {
            button[2].interactable = false;
        }
        if (PlayerPrefs.GetInt("hasClaim3") == 1)
        {
            button[3].interactable = false;
        }
        if (PlayerPrefs.GetInt("hasClaim4") == 1)
        {
            button[4].interactable = false;
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
