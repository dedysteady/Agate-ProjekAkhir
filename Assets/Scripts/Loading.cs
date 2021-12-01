using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    float time, second;
    [SerializeField] public Image _image;
    // Start is called before the first frame update
    void Start()
    {
        second = 5;
        Invoke("LoadGame", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            _image.fillAmount = time / second;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
