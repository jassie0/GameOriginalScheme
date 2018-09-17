using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManger : MonoBehaviour {
	public Text moneyText;
	public int currentGold;
	public int goldAddedinCurrentLevel = 0;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("CurrentMoney", 0);
		if (PlayerPrefs.HasKey ("CurrentMoney")) {
			currentGold = PlayerPrefs.GetInt ("CurrentMoney");
		} else {
			currentGold = 0;
			PlayerPrefs.SetInt ("CurrentMoney", 0);
		}

		if(moneyText != null)
		{
			moneyText.text = "金币：" + currentGold;
		}
		UIControl.Instance().SetScore(goldAddedinCurrentLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMoney (int goldToAdd) {
		goldAddedinCurrentLevel += goldToAdd;
		currentGold += goldAddedinCurrentLevel;
		PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		if(moneyText != null)
		{
			moneyText.text = "金币：" + currentGold;
		}
		UIControl.Instance().SetScore(goldAddedinCurrentLevel);
	}
}
