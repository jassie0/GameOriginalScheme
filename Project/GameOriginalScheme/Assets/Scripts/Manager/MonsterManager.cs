using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour 
{
	public GameObject _monsterPerfab;

	public float _radius = 10f;

    public float _minTime = 0f;
    public float _maxTime = 5f;


	public void CreateMonster(GameObject player)
	{
		StartCoroutine (CreatingMonster (player));
	}

	public void CreateOneMonster(GameObject player)
	{
		if (_monsterPerfab != null)
		{
			GameObject monsterObj = Instantiate(_monsterPerfab, RandomPosition(), Quaternion.identity);
			if (monsterObj == null) 
			{
				Debug.LogError ("Create monster error");
			}

			MonsterController monster = monsterObj.GetComponent<MonsterController> ();
			if (monster == null) 
			{
				Debug.LogError ("Create monster error");
			}
				
			monster.InitMonster (player);
		}
	}

	IEnumerator CreatingMonster(GameObject player)
	{
		while (true) 
		{
			CreateOneMonster (player);
			yield return new WaitForSeconds(Random.Range(0f, 5f));
		}
	}

	void OnTriggerEnter(object other)
	{
		Destroy (this.gameObject);
	}

	public Vector2 RandomPosition()
	{
		Vector2 p = Random.insideUnitCircle;//将位置设置为一个半径为radius中心点在原点的圆圈内的某个点X.
        Vector2 pos = p.normalized * (_radius + p.magnitude);//某个点X的单位向量乘以随机出来的长度(这个随机点是以圆心为中心半径5之外,10之内的点)
        return pos;
	}


}
