using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    public int currentHint = 0, Hint, HintUse;
    public Text hintText;

    public List<Dragdrop> list = new List<Dragdrop>();
    public GameObject[] showNumber;
    bool useHint;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hint"))
        {
            currentHint = PlayerPrefs.GetInt("Hint");
        }
        if (PlayerPrefs.HasKey("HintUse"))
        {
            HintUse = PlayerPrefs.GetInt("HintUse");
        }
    }

    // Update is called once per frame
    public void Update()
    {
        hintText.text = currentHint.ToString();
    }

    public void UseHintJigsaw()
    {
        int randomIndex = Random.Range(0, list.Count);

        if (currentHint > 0)
        {
            if (list[randomIndex].onTempel)
            {
                list.Remove(list[randomIndex]);
                UseHintJigsaw();
            }
            else
            {
                list[randomIndex].onPos = true;
                list[randomIndex].OnMouseUp();
                list.Remove(list[randomIndex]);
                currentHint--;
                HintUse++;
            }
            
        }
        else
        {
            currentHint = 0;
            Debug.Log("The list is empty: ");
        }

        PlayerPrefs.SetInt("Hint", currentHint);
        PlayerPrefs.SetInt("HintUse", HintUse);
    }

    public void UseHintSliding()
    {
        if(currentHint > 0)
        {
            if (!useHint)
            {
                foreach (GameObject number in showNumber)
                {
                    number.SetActive(true);
                }
                currentHint--;
                HintUse++;
                useHint = true;
            }
            else
                Debug.Log("you already used hint");

        }
        else
        {
            currentHint = 0;
        }

        PlayerPrefs.SetInt("Hint", currentHint);
        PlayerPrefs.SetInt("HintUse", HintUse);

    }
}
