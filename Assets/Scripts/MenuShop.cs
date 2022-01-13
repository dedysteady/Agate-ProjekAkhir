using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuShop : MonoBehaviour
{
    public HintManager hintManager;
    public CoinManager coinManager;

    public GameObject popup;
    public Text textHint;

    int coin, hint, BuyHint;

    public Soundsfx soundsfx;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            coinManager.currentCoin = PlayerPrefs.GetInt("Coin");
        }
        if (PlayerPrefs.HasKey("Hint"))
        {
            hintManager.currentHint = PlayerPrefs.GetInt("Hint");
        }
        if (PlayerPrefs.HasKey("BuyHint"))
        {
            BuyHint = PlayerPrefs.GetInt("BuyHint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PriceHint(int price)
    {
        switch (price)
        {
            case 1:
                Debug.Log("bayar 100");
                coin = 100;
                hint = 1;
                break;

            case 2:
                Debug.Log("bayar 200");
                coin = 200;
                hint = 3;
                break;

            case 3:
                Debug.Log("bayar 300");
                coin = 300;
                hint = 5;
                break;

            case 4:
                Debug.Log("bayar 550");
                coin = 550;
                hint = 10;
                break;
        }

        if (coinManager.currentCoin >= coin)
        {
            coinManager.currentCoin -= coin;
            hintManager.currentHint += hint;
            BuyHint += hint;
            PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
            PlayerPrefs.SetInt("Hint", hintManager.currentHint);
            PlayerPrefs.SetInt("BuyHint", BuyHint);
            soundsfx.PlayGetReward();
            popup.SetActive(true);
            textHint.text = hint.ToString() + " Hint";
        }
        else
        {
            Debug.Log("You don't have enough money");
        }

    }
    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }
}
