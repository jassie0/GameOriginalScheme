using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

//	private GameObject[] _players;
//	public MonsterManager _monsterManager;
//    public GameHelp _gameHelp;
//
//	public static GameController instance;
//
//	void Awake () 
//    {
//		instance = this;
//	}
//
//	void Start()
//	{
//		
//		_players = GameObject.FindGameObjectsWithTag ("Player");
//		foreach (GameObject p in _players) {
//			_monsterManager.CreateMonster (p);
//		}
//
//	}


	void Start(){
	
	}
	public void PlayerDied(){
	
	}

	IEnumerator RestartLevel() {
		yield return new WaitForSeconds (1f);
	}
}
