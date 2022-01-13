using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public Text starsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStarsUI();
    }

    void UpdateStarsUI()
    {
        int Sum = 0;
        for(int i = 1; i < 14; i++)
        {
            Sum += PlayerPrefs.GetInt("Lv" + i.ToString());
        }

        starsText.text = Sum + "/" + 39;
    }

    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }
}
