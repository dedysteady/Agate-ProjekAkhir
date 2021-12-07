using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] float time, second;
    public Image FillImage;

    // Start is called before the first frame update
    void Start()
    {
        second = 3;
        Invoke("LoadGame", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 5)
        {
            time += Time.deltaTime;
            FillImage.fillAmount = time / second;
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
