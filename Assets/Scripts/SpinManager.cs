using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpinManager : MonoBehaviour
{
    public HintManager hintManager;
    public CoinManager coinManager;
    public SoundManager soundManager;
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
            soundManager.PlaySpin();
        }
        if (spin && speed <= 0)//end of speed
        {
            for (int i = 0; i < angle.Length; i++)
            {
                if (transform.rotation.eulerAngles.z == angle[i])
                {
                    transform.Rotate(0, 0, -325);
                    break;
                }
            }
            if ((transform.rotation.eulerAngles.z > angle[0] && transform.rotation.eulerAngles.z < angle[1]) || (transform.rotation.eulerAngles.z < angle[15] && transform.rotation.eulerAngles.z > angle[16]))
                {reward_txt.text = "25 Coin";   
                coinManager.currentCoin += 25;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }  

            if ((transform.rotation.eulerAngles.z > angle[1] && transform.rotation.eulerAngles.z < angle[2]) || (transform.rotation.eulerAngles.z < angle[14] && transform.rotation.eulerAngles.z > angle[15]))
                {reward_txt.text = "1 Hint";
                hintManager.currentHint += 1;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }
          
            if ((transform.rotation.eulerAngles.z > angle[2] && transform.rotation.eulerAngles.z < angle[3]) || (transform.rotation.eulerAngles.z < angle[13] && transform.rotation.eulerAngles.z > angle[14]))
                {reward_txt.text = "50 Coin";
                coinManager.currentCoin += 50;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }
     
            if ((transform.rotation.eulerAngles.z > angle[3] && transform.rotation.eulerAngles.z < angle[4]) || (transform.rotation.eulerAngles.z < angle[12] && transform.rotation.eulerAngles.z > angle[13]))
                {reward_txt.text = "3 Hint"; 
                hintManager.currentHint += 3;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }

            if ((transform.rotation.eulerAngles.z > angle[4] && transform.rotation.eulerAngles.z < angle[5]) || (transform.rotation.eulerAngles.z < angle[11] && transform.rotation.eulerAngles.z > angle[12]))
                {reward_txt.text = "1000 Coin";                  
                coinManager.currentCoin += 1000;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }    

            if ((transform.rotation.eulerAngles.z > angle[5] && transform.rotation.eulerAngles.z < angle[6]) || (transform.rotation.eulerAngles.z < angle[10] && transform.rotation.eulerAngles.z > angle[11]))
                {reward_txt.text = "2 Hint";
                hintManager.currentHint += 2;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }

            if ((transform.rotation.eulerAngles.z > angle[6] && transform.rotation.eulerAngles.z < angle[7]) || (transform.rotation.eulerAngles.z < angle[9] && transform.rotation.eulerAngles.z > angle[10]))  
                {reward_txt.text = "200 Coin";
                coinManager.currentCoin += 200;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }
        
            if ((transform.rotation.eulerAngles.z > angle[7] && transform.rotation.eulerAngles.z < angle[8]) || (transform.rotation.eulerAngles.z < angle[0] && transform.rotation.eulerAngles.z > angle[9]))
                {reward_txt.text = "100 Coin"; 
                coinManager.currentCoin += 100;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }  

            speed = 0;
            spin = false;
            popUp.SetActive(true);
        }
    }


    public void chance()
    {
        spin = true;

        if (Random.value >= 0 && Random.value <= 0.05) 
        {
            speed = 42;
        }
     
        if (Random.value > 0.05 && Random.value <= 0.1) 
        { 
            speed = 41;
        }
     
        if (Random.value > 0.1 && Random.value <= 0.15) 
        { 
            speed = 50;
        }

        if (Random.value > 0.15 && Random.value <= 0.2) 
        {
            speed = 43;
        }
     
        if (Random.value > 0.2 && Random.value <= 0.6) 
        { 
            speed = 37;
        }
     
        if (Random.value > 0.6 && Random.value <= 0.7) 
        { 
            speed = 39;
        }

        if (Random.value > 0.7 && Random.value <= 0.9) 
        { 
            speed = 40;
        }
     
        if (Random.value > 0.9 && Random.value <= 1) 
        { 
            speed = 44;
        }
    }

}


// 37 = 25 coin
// 39 = 1 hint
// 40 = 50 coin
// 41 = 3 hint
// 42 = 1000 coin
// 43 = 2 hint
// 50 = 200 coin
// 44 = 100 coin