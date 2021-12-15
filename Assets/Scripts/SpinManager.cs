using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpinManager : MonoBehaviour
{
    public HintManager hintManager;
    public CoinManager coinManager;
    public GameObject popUp;
    int coin, hint;
    
    private bool spin;
    private float speed;
    public Text reward_txt;
    private int[] angle = new int[] { 0, 45, 90, 135, 180, 225, 270, 315, 360, -45, -90, -135, -180, -225, -270, -315, -360};
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        spin = false;

        if (PlayerPrefs.HasKey("Coin"))
        {
            coinManager.currentCoin = PlayerPrefs.GetInt("Coin");
        }
        if (PlayerPrefs.HasKey("Hint"))
        {
            hintManager.currentHint = PlayerPrefs.GetInt("Hint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spin && speed > 0)
        {
            transform.Rotate(0, 0, speed);
            speed -= .1f;
        }
        if (spin && speed <= 0)//end of speed
        {
            for (int i = 0; i < angle.Length; i++)
            {
                if (transform.rotation.eulerAngles.z == angle[i])
                {
                    transform.Rotate(0, 0, 1);
                    break;
                }
            }
            if ((transform.rotation.eulerAngles.z > angle[0] && transform.rotation.eulerAngles.z < angle[1]) || (transform.rotation.eulerAngles.z < angle[15] && transform.rotation.eulerAngles.z > angle[16]))
                {reward_txt.text = "5000 Coin";
                coinManager.currentCoin += 5000;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }
            if ((transform.rotation.eulerAngles.z > angle[1] && transform.rotation.eulerAngles.z < angle[2]) || (transform.rotation.eulerAngles.z < angle[14] && transform.rotation.eulerAngles.z > angle[15]))
                {reward_txt.text = "100 Coin"; 
                coinManager.currentCoin += 100;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }            
            if ((transform.rotation.eulerAngles.z > angle[2] && transform.rotation.eulerAngles.z < angle[3]) || (transform.rotation.eulerAngles.z < angle[13] && transform.rotation.eulerAngles.z > angle[14]))
                {reward_txt.text = "200 Coin";   
                coinManager.currentCoin += 200;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }         
            if ((transform.rotation.eulerAngles.z > angle[3] && transform.rotation.eulerAngles.z < angle[4]) || (transform.rotation.eulerAngles.z < angle[12] && transform.rotation.eulerAngles.z > angle[13]))
                {reward_txt.text = "1 Hint";
                hintManager.currentHint += 1;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }
            if ((transform.rotation.eulerAngles.z > angle[4] && transform.rotation.eulerAngles.z < angle[5]) || (transform.rotation.eulerAngles.z < angle[11] && transform.rotation.eulerAngles.z > angle[12]))
                {reward_txt.text = "1000 Coin";
                coinManager.currentCoin += 1000;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }
            if ((transform.rotation.eulerAngles.z > angle[5] && transform.rotation.eulerAngles.z < angle[6]) || (transform.rotation.eulerAngles.z < angle[10] && transform.rotation.eulerAngles.z > angle[11]))
                {reward_txt.text = "3 Hint"; 
                hintManager.currentHint += 3;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }
            if ((transform.rotation.eulerAngles.z > angle[6] && transform.rotation.eulerAngles.z < angle[7]) || (transform.rotation.eulerAngles.z < angle[9] && transform.rotation.eulerAngles.z > angle[10]))
                {reward_txt.text = "2000 Coin";                  
                coinManager.currentCoin += 2000;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }            
            if ((transform.rotation.eulerAngles.z > angle[7] && transform.rotation.eulerAngles.z < angle[8]) || (transform.rotation.eulerAngles.z < angle[0] && transform.rotation.eulerAngles.z > angle[9]))
                {reward_txt.text = "5 Hint";
                hintManager.currentHint += 5;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }
            speed = 0;
            spin = false;
            popUp.SetActive(true);
        }
    }


    public void chance()
    {
        spin = true;

        if (Random.value > 0 && Random.value <= 0.5) //%50 percent chance
        {
            speed = 44;
        }
     
        if (Random.value > 0.5 && Random.value <= 0.1) //%80 percent chance (1 - 0.2 is 0.8)
        { 
            speed = 17;
        }
     
        if (Random.value > 0.1 && Random.value <= 0.15) //%30 percent chance (1 - 0.7 is 0.3)
        { 
            speed = 50;
        }

        if (Random.value > 0.15 && Random.value <= 0.2) //%50 percent chance
        {
            speed = 25;
        }
     
        if (Random.value > 0.2 && Random.value <= 0.3) //%80 percent chance (1 - 0.2 is 0.8)
        { 
            speed = 10;
        }
     
        if (Random.value > 0.3 && Random.value <= 0.4) //%30 percent chance (1 - 0.7 is 0.3)
        { 
            speed = 20;
        }

        if (Random.value > 0.4 && Random.value <= 0.8) //%80 percent chance (1 - 0.2 is 0.8)
        { 
            speed = 15;
        }
     
        if (Random.value > 0.8) //%30 percent chance (1 - 0.7 is 0.3)
        { 
            speed = 40;
        }
    }

}

// 10 = 1 hint
// 15 = 100 coin
// 20 = 1000 coin
// 25 = 3 hint
// 17 = 5000 coin
// 40 = 200 coin
// 44 = 5 hint
// 50 = 2000 coin