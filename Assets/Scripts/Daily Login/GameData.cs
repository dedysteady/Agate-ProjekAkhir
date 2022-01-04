using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    static int coin;
    static int hint;

    static GameData()
    {
        coin = PlayerPrefs.GetInt("Coin");
        hint = PlayerPrefs.GetInt("Hint");
    }

    public static int Coin
    {
        get { return coin; }
        set
        {
            coin = value;
            PlayerPrefs.SetInt("Coin", coin);
        }
    }

    public static int Hint
    {
        get { return hint; }
        set
        {
            hint = value;
            PlayerPrefs.SetInt("Hint", hint);
        }
    }
}
