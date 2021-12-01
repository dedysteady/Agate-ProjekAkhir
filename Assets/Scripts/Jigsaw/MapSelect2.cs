using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelect2 : MonoBehaviour
{
    public Text starsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStarsUI2();
    }

    void UpdateStarsUI2()
    {
        int Sum = 0;
        for(int i = 1; i < 14; i++)
        {
            Sum += PlayerPrefs.GetInt("Lv" + i.ToString());
        }

        starsText.text = Sum + "/" + 15;
    }

    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }
}