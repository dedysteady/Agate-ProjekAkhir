using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int currentCoin = 0, coinReward;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            currentCoin = PlayerPrefs.GetInt("Coin");
            coinText.text = currentCoin.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoin()
    {
        currentCoin += coinReward;
        PlayerPrefs.SetInt("Coin", currentCoin);
        coinText.text = currentCoin.ToString();
    }
}
