using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Button button;
    public bool unlocked, hasClaim;
    public int coin, hint;
    
    public CoinManager coinManager;
    public HintManager hintManager;

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
            }
            
        }
        else
        {
            Debug.Log("nothing");
        }
    }
}
