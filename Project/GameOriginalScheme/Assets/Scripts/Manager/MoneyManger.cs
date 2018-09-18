using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManger : MonoSingleton<MoneyManger> {
	//public Text moneyText;
	public static int currentGold;
	public static int goldAddedinCurrentLevel = 0;
	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.HasKey ("CurrentMoney")) {
			currentGold = PlayerPrefs.GetInt ("CurrentMoney");
		} else {
			currentGold = 0;
			PlayerPrefs.SetInt ("CurrentMoney", 0);
		}

		// if(moneyText != null)
		// {
		// 	moneyText.text = "金币：" + currentGold;
		// }
		UIControl.Instance().SetScore(goldAddedinCurrentLevel);
	}

	public void AddMoney (int goldToAdd) {
		goldAddedinCurrentLevel += goldToAdd;
		currentGold += goldAddedinCurrentLevel;
		PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		// if(moneyText != null)
		// {
		// 	moneyText.text = "金币：" + currentGold;
		// }
		UIControl.Instance().SetScore(goldAddedinCurrentLevel);
	}

	public void ResetGold()
	{
		goldAddedinCurrentLevel = 0;
	}

	public int GetCurrentGold()
	{
		return goldAddedinCurrentLevel;
	}
}
