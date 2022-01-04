using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private AudioSource player;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BgmMuteUnMute();

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level 1 Jigsaw" || currentScene.name == "Level 2 Jigsaw" ||
           currentScene.name == "Level 3 Jigsaw" || currentScene.name == "Level 4 Jigsaw"
           || currentScene.name == "Level 5 Jigsaw"|| currentScene.name == "Level 1 Sliding" || currentScene.name == "Level 2 Sliding" ||
            currentScene.name == "Level 3 Sliding" || currentScene.name == "Level 4 Sliding"
            || currentScene.name == "Level 5 Sliding")
        {
            Destroy(gameObject);
        }
    }

    public void BgmMuteUnMute()
    {
        if (PlayerPrefs.GetInt("bgm") == 1)
        {
            player.mute = true;
        }
        else
        {
            player.mute = false;
        }
    }    
}
