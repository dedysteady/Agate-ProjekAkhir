using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace DailyRewardSystem
{
	public enum RewardType
	{
		Coins,
		Hints
	}

	[Serializable]
	public struct Reward
	{
		public RewardType Type;
		public int Amount;
	}

	public class DailyRewards : MonoBehaviour
	{
		[Header("Main Menu UI")]
		public CoinManager coinManager;
		public HintManager hintManager;

		[Space]
		[Header("Reward UI")]
		[SerializeField] Text rewardAmountText;
		[SerializeField] Button claimButton;
		[SerializeField] GameObject rewardsNotification;
		[SerializeField] GameObject maskot;
		[SerializeField] GameObject noMoreRewardsPanel;
		[SerializeField] Text nextReward;

		[Space]
		[Header("Rewards Database")]
		[SerializeField] RewardsDatabase rewardsDB;

		[Space]
		[Header("Timing")]
		//wait 23 Hours to activate the next reward (it's better to use 23h instead of 24h)
		[SerializeField] double nextRewardDelay = 23f;
		//check if reward is available every 5 seconds
		[SerializeField] float checkForRewardDelay = 5f;


		private int nextRewardIndex;
		private bool isRewardReady = false;

		void Start()
		{
			Initialize();
			StopAllCoroutines();
			StartCoroutine(CheckForRewards());
		}

        private void Update()
        {

		}

        void Initialize()
		{
			nextRewardIndex = PlayerPrefs.GetInt("Next_Reward_Index", 0);
			
			//Check if the game is opened for the first time then set Reward_Claim_Datetime to the current datetime
			if (string.IsNullOrEmpty(PlayerPrefs.GetString("Reward_Claim_Datetime")))
				PlayerPrefs.SetString("Reward_Claim_Datetime", DateTime.Now.ToString());
		}

		IEnumerator CheckForRewards()
		{
			while (true)
			{
				if (!isRewardReady)
				{
					DateTime currentDatetime = DateTime.Now;
					DateTime rewardClaimDatetime = DateTime.Parse(PlayerPrefs.GetString("Reward_Claim_Datetime", currentDatetime.ToString()));

					//get total Hours between this 2 dates
					double elapsedHours = (currentDatetime - rewardClaimDatetime).TotalHours; //TotalSeconds for try features
					nextReward.text = elapsedHours.ToString();

					if (elapsedHours >= nextRewardDelay)
                    {
						ActivateReward();
					}
					else
						DesactivateReward();
				}

				yield return new WaitForSeconds(checkForRewardDelay);
			}
		}

		void ActivateReward()
		{
			isRewardReady = true;

			maskot.SetActive(true);
			noMoreRewardsPanel.SetActive(false);
			rewardsNotification.SetActive(true);

			//Update Reward UI
			Reward reward = rewardsDB.GetReward(nextRewardIndex);

			//Amount
			rewardAmountText.text = string.Format("+{0} ", reward.Amount) + reward.Type;

		}

		void DesactivateReward()
		{
			isRewardReady = false;

			maskot.SetActive(false);
			noMoreRewardsPanel.SetActive(true);
			rewardsNotification.SetActive(false);
		}

		public void OnClaimButtonClick()
		{
			Reward reward = rewardsDB.GetReward(nextRewardIndex);

			//check reward type
			if (reward.Type == RewardType.Coins)
			{
				Debug.Log("<color=white>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
				GameData.Coin += reward.Amount;
				UpdateCoinsTextUI();
			}
			else if (reward.Type == RewardType.Hints)
			{
				Debug.Log("<color=yellow>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
				GameData.Hint += reward.Amount;
				UpdateHintsTextUI();
			}

			//Save next reward index
			nextRewardIndex++;
			if (nextRewardIndex >= rewardsDB.rewardsCount)
				nextRewardIndex = 0;

			PlayerPrefs.SetInt("Next_Reward_Index", nextRewardIndex);

			//Save DateTime of the last Claim Click
			PlayerPrefs.SetString("Reward_Claim_Datetime", DateTime.Now.ToString());

			DesactivateReward();
		}

		//Update Mainmenu UI
		void UpdateCoinsTextUI()
		{
			coinManager.currentCoin = GameData.Coin;
		}

		void UpdateHintsTextUI()
		{
			hintManager.currentHint = GameData.Hint;
		}
	}

}

