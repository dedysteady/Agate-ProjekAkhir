using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCondition : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject[] pos;
    public Text time, coin;
    [SerializeField]bool selesai = false;

    public TimeManager timeManager;
    public SingleLevelJigsaw singleLevelJigsaw;
    public CoinManager coinManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!selesai)
        {
            CekPuzzle();
        }
    }

    public void CekPuzzle()
    {
        for(int i = 0; i < pos.Length; i++)
        {
            if (transform.GetChild(i).GetComponent<Dragdrop>().onTempel)
            {
                selesai = true;
                time.text = timeManager.timeText.text;
            }
            else
            {
                selesai = false;
                i = pos.Length;
            }
        }

        if (selesai)
        {
            timeManager.timeActive = false;
            gameManager.WinCondition();
            gameManager.TimeStarJigsaw();
            singleLevelJigsaw.UpdateStar();
            coinManager.UpdateCoin();
            coin.text = coinManager.coinText.text;
        }
    }
}
