using DailyRewardSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RewardsDB", menuName = "Daily Rewards System/Rewards Database")]
public class RewardsDatabase : ScriptableObject
{
    public Reward[] rewards;

    public int rewardsCount
    {
        get { return rewards.Length; }
    }

    public Reward GetReward(int index)
    {
        return rewards[index];
    }
}
