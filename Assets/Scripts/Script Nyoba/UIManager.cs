using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanels;

    [Header("Our STAR UI")]
    public int stars;
    public Text startText;
    public MapSelection[] mapSelections;
    public Text[] unlockStarsText;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }

    private void update()
    {
        UpdateStarUI();
        UpdateUnlockedStarUI();
    }


    private void UpdateUnlockedStarUI()
    {
        for(int i=0; i < mapSelections.Length; i++)
        {
            unlockStarsText[i].text = stars.ToString() + "/" + mapSelections[i].endLevel * 3;
        }
    }

    private void UpdateStarUI()
    {
        startText.text = stars.ToString();
    }

    public void PressMapButton(int _mapIndex)
    {
        if(mapSelections[_mapIndex].isUnlock == true)
        {
            levelSelectionPanels[_mapIndex].gameObject.SetActive(true);
            mapSelectionPanel.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You cannot open!!!");
        }
    }

}
