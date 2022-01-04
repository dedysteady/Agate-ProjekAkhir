using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Text text;
    public GameObject popup;
    public bool unlocked, hasClaim;
    public int coin, hint;
    public string reward;
    
    public CoinManager coinManager;
    public HintManager hintManager;
    public MenuQuest menuQuest;
    public Soundsfx soundsfx;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Achievement()
    {
        if (unlocked)
        {
            if (!hasClaim)
            {
                coinManager.currentCoin += coin;
                hintManager.currentHint += hint;

                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);

                hasClaim = true;
                menuQuest.HasClaim();
                soundsfx.PlayGetReward();

                popup.SetActive(true);
                text.text = reward;
            }
            
        }
        else
        {
            Debug.Log("nothing");
        }
    }
}
