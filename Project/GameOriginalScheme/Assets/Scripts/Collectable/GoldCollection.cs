using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollection : MonoBehaviour {
	public int value;
	public MoneyManger moneyManager;
	// Use this for initialization
	void Start () {
		moneyManager = FindObjectOfType<MoneyManger> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "King"){
            if (moneyManager != null)
            {
                moneyManager.AddMoney(value);
            }
			
			SoundManager.Instance().PlaySound("getCoin");
			Destroy (gameObject);
		}
	}
}
