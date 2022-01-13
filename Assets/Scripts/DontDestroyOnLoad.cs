using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad (transform.gameObject);
        }
    }

    void Update()
     {
         Scene currentScene = SceneManager.GetActiveScene();
     
         if (currentScene.name == "Level 1 Jigsaw" || currentScene.name == "Level 2 Jigsaw" ||
            currentScene.name == "Level 3 Jigsaw" || currentScene.name == "Level 4 Jigsaw"
            || currentScene.name == "Level 5 Jigsaw")
         {
             Destroy(gameObject);
         }

         if (currentScene.name == "Level 1 Sliding" || currentScene.name == "Level 2 Sliding" ||
            currentScene.name == "Level 3 Sliding" || currentScene.name == "Level 4 Sliding"
            || currentScene.name == "Level 5 Sliding")
         {
             Destroy(gameObject);
         }
     }
}
