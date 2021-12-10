using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Text starsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Select Mini Map Jigsaw")
        {
            UpdateStarsUIJigsaw();
        }
        else if (SceneManager.GetActiveScene().name == "Select Mini Map Sliding")
        {
            UpdateStarsUISliding();
        }
    }

    void UpdateStarsUIJigsaw()
    {
        int sum = 0;
        for(int i = 0; i < 5; i++)
        {
            sum += PlayerPrefs.GetInt("Jigsaw Lv" + i.ToString());
        }

        starsText.text = sum + "/" + 15;
    }

    void UpdateStarsUISliding()
    {
        int sum = 0;
        for (int i = 0; i < 5; i++)
        {
            sum += PlayerPrefs.GetInt("Sliding Lv" + i.ToString());
        }

        starsText.text = sum + "/" + 15;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
