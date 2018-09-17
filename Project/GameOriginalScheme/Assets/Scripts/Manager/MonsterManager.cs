using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour 
{
	public List<GameObject> _monsterPerfab;
    public List<GameObject> _monsterSpawner;
    public List<GameObject> _dingPerfab;
    public List<GameObject> _dingSpawner;

    public float _monsterMinTime = 2f;
    public float _monsterMaxTime = 5f;

    public float _dingMinTime = 2f;
    public float _dingMaxTime = 5f;

    private GameObject m_player;
    public float checkRadius = 1;
    public LayerMask checkLayers;

    private void Start()
    {
        m_player = PlayerController.GetPlayerObject();
        StartCoroutine(CreatingDing());
        StartCoroutine(CreatingMonster());
    }

	public void CreateOneMonster()
	{
		if (_monsterPerfab != null)
		{
            int randomMonster = Random.Range(0, _monsterPerfab.Count);
            int randomSpawn = Random.Range(0, _monsterSpawner.Count);

            GameObject monsterObj = Instantiate(_monsterPerfab[randomMonster], _monsterSpawner[randomSpawn].transform.position, Quaternion.identity);
			if (monsterObj == null) 
			{
				Debug.LogError ("Create monster error");
			}

            DistoryThisAfterAWhile dis = monsterObj.AddComponent<DistoryThisAfterAWhile>();
            if(dis == null)
            {
                return;
            }
            dis.SetTime(180);
        }
	}

	IEnumerator CreatingMonster()
	{
		while (true) 
		{
			CreateOneMonster ();
            yield return new WaitForSeconds(Random.Range(_monsterMinTime, _monsterMaxTime));
		}
	}

    public void CreatingOneDing()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, checkRadius, checkLayers);

        if (colliders.Length > 0)
        {
            return;
        }

        int randomDing = Random.Range(0, _dingPerfab.Count);
        int randomSpawn = Random.Range(0, _dingSpawner.Count);

        GameObject ding = Instantiate(_dingPerfab[randomDing], _dingSpawner[randomSpawn].transform.position, Quaternion.identity);
        if(ding == null)
        {
            return;
        }
        DistoryThisAfterAWhile dis = ding.AddComponent<DistoryThisAfterAWhile>();
        if(dis == null)
        {
            return;
        }
        dis.SetTime(120);

    }

    IEnumerator CreatingDing()
    {
        while(true)
        {
            CreatingOneDing();
            yield return new WaitForSeconds(Random.Range(_monsterMinTime, _monsterMaxTime));
        }
    }

	//void OnTriggerEnter(object other)
	//{
	//	Destroy (this.gameObject);
	//}

	//public Vector2 RandomPosition()
	//{
	//	Vector2 p = Random.insideUnitCircle;//将位置设置为一个半径为radius中心点在原点的圆圈内的某个点X.
    //  Vector2 pos = p.normalized * (_radius + p.magnitude);//某个点X的单位向量乘以随机出来的长度(这个随机点是以圆心为中心半径5之外,10之内的点)
    //  return pos;
	//}


}
