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
    public AudioSource audioSource;
    public Soundsfx soundsfx;
    
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
                    transform.Rotate(0, 0, 150);
                    break;
                }
            }
            if ((transform.rotation.eulerAngles.z > angle[0] && transform.rotation.eulerAngles.z < angle[1]) || (transform.rotation.eulerAngles.z < angle[15] && transform.rotation.eulerAngles.z > angle[16]))
                {reward_txt.text = "10 Coin";   
                coinManager.currentCoin += 10;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }  

            if ((transform.rotation.eulerAngles.z > angle[1] && transform.rotation.eulerAngles.z < angle[2]) || (transform.rotation.eulerAngles.z < angle[14] && transform.rotation.eulerAngles.z > angle[15]))
                {reward_txt.text = "3 Hint";
                hintManager.currentHint += 3;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }
          
            if ((transform.rotation.eulerAngles.z > angle[2] && transform.rotation.eulerAngles.z < angle[3]) || (transform.rotation.eulerAngles.z < angle[13] && transform.rotation.eulerAngles.z > angle[14]))
                {reward_txt.text = "150 Coin";
                coinManager.currentCoin += 150;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }
     
            if ((transform.rotation.eulerAngles.z > angle[3] && transform.rotation.eulerAngles.z < angle[4]) || (transform.rotation.eulerAngles.z < angle[12] && transform.rotation.eulerAngles.z > angle[13]))
                {reward_txt.text = "2 Hint"; 
                hintManager.currentHint += 2;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }

            if ((transform.rotation.eulerAngles.z > angle[4] && transform.rotation.eulerAngles.z < angle[5]) || (transform.rotation.eulerAngles.z < angle[11] && transform.rotation.eulerAngles.z > angle[12]))
                {reward_txt.text = "100 Coin";                  
                coinManager.currentCoin += 100;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }    

            if ((transform.rotation.eulerAngles.z > angle[5] && transform.rotation.eulerAngles.z < angle[6]) || (transform.rotation.eulerAngles.z < angle[10] && transform.rotation.eulerAngles.z > angle[11]))
                {reward_txt.text = "50 Coin";
                hintManager.currentHint += 50;
                PlayerPrefs.SetInt("Hint", hintManager.currentHint);
                }

            if ((transform.rotation.eulerAngles.z > angle[6] && transform.rotation.eulerAngles.z < angle[7]) || (transform.rotation.eulerAngles.z < angle[9] && transform.rotation.eulerAngles.z > angle[10]))  
                {reward_txt.text = "30 Coin";
                coinManager.currentCoin += 30;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }
        
            if ((transform.rotation.eulerAngles.z > angle[7] && transform.rotation.eulerAngles.z < angle[8]) || (transform.rotation.eulerAngles.z < angle[0] && transform.rotation.eulerAngles.z > angle[9]))
                {reward_txt.text = "1 Hint"; 
                coinManager.currentCoin += 1;
                PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
                }  

            speed = 0;
            spin = false;
            popUp.SetActive(true);
            audioSource.Stop();
            soundsfx.PlayVictory();            
        }
    }


    public void chance()
    {
        spin = true;

        if (Random.value >= 0 && Random.value <= 0.05) 
        {
            speed = 40;
        }
     
        if (Random.value > 0.05 && Random.value <= 0.1) 
        { 
            speed = 39;
        }
     
        if (Random.value > 0.1 && Random.value <= 0.15) 
        { 
            speed = 42;
        }

        if (Random.value > 0.15 && Random.value <= 0.2) 
        {
            speed = 41;
        }
     
        if (Random.value > 0.2 && Random.value <= 0.6) 
        { 
            speed = 37;
        }
     
        if (Random.value > 0.6 && Random.value <= 0.7) 
        { 
            speed = 43;
        }

        if (Random.value > 0.7 && Random.value <= 0.9) 
        { 
            speed = 44;
        }
     
        if (Random.value > 0.9 && Random.value <= 1) 
        { 
            speed = 50;
        }
    }

}


// 37 = 10 coin
// 39 = 3 hint
// 40 = 150 coin
// 41 = 2 hint
// 42 = 100 coin
// 43 = 50 coin
// 50 = 30 coin
// 44 = 1 hint