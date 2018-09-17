using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossScene : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("King")) {
			UIControl.Instance ().LoadScene ("Boss");
			SoundManager.Instance ().PlayBGM ("bossFightBGM");
		}
	}
}
