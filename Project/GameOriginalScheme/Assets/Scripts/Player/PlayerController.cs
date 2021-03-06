﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Direction
{
	Up,
	Right,
	Down,
	Left,
    Max
}

public class PlayerController : MonoSingleton<PlayerController>  
{
    public Rigidbody2D m_playerRigidbody;
	public float speed;
	public float rotateSpeed;
	public GameObject moveDes;
   
	public SkillBox[] m_skillBox;
	public float angle = 1;
	public float m_radius = 2f;

	//private bool isMoving;
	//private Vector3 target;
	private Direction m_targetKey = Direction.Up;
	private Dictionary<Direction, Vector3> m_currentPosition = new Dictionary<Direction, Vector3>();
	private const float m_Distance = 0.05f;
	private float m_rotateDirection = -1;//-1顺时针， 1逆时针
	private Dictionary<Direction, SkillBox> m_skillBoxDic = new Dictionary<Direction, SkillBox>();

	public bool playerMoving;
	public Vector2 lastMove;
	public bool PlayerAlive;
    public float h;
    public float v;

	public GameObject animSprite;
	Animator animator;
    static GameObject _player;

	private const float m_fReagan = 0.707f;      //sin45度角除以2，用于计算攻击方向

	void Awake()
	{
		InitCurrentPosition();
        _player = gameObject;

        
	}

	void Start()
	{
		Time.timeScale = 1;
		animator = animSprite.GetComponent<Animator> ();
        ResetSkillBoxDistance();
        ResetSkillBoxDic(m_targetKey);
		PlayerAlive = GetComponent<DieAndRespawnController> ().Alive;
    }


	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 unitVector = ((Vector2)worldPos - (Vector2)gameObject.transform.position).normalized;

			if(unitVector.y > m_fReagan)
			{
				SkillBox skillBox = m_skillBoxDic [Direction.Up];
				skillBox.UseSkill ();
			}
			else if(unitVector.x > m_fReagan)
			{
				SkillBox skillBox = m_skillBoxDic [Direction.Right];
				skillBox.UseSkill ();
			}
			else if(unitVector.y < -m_fReagan)
			{
				SkillBox skillBox = m_skillBoxDic [Direction.Down];
				skillBox.UseSkill ();
			}
			else
			{
				SkillBox skillBox = m_skillBoxDic [Direction.Left];
				skillBox.UseSkill ();
			}
		}
	}

	void FixedUpdate()
	{
		if (PlayerAlive) {
			if (NeedToRotate ()) {
				for (int i = 0; i < m_skillBox.Length; i++) {
					m_skillBox [i].transform.position = RotateAroundPivot (m_skillBox [i].transform.position, transform.position, Quaternion.Euler (0, 0, angle * m_rotateDirection));
				}
			} else {
				if (Input.GetKeyDown (KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0) 
				{
					m_targetKey = GetNextDirection (false);
					ResetSkillBoxDic (m_targetKey);
					m_rotateDirection = 1;
                    SoundManager.Instance().PlaySound("stoneMoving");

				} else if (Input.GetKeyDown (KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0) 
				{
					m_targetKey = GetNextDirection (true);
					ResetSkillBoxDic (m_targetKey);
					m_rotateDirection = -1;
                    SoundManager.Instance().PlaySound("stoneMoving");
				}
			}

			playerMoving = false;

			h = Input.GetAxisRaw ("Horizontal");
			v = Input.GetAxisRaw ("Vertical");

			if (h > 0.5f || v > 0.5f || h < -0.5f || v < -0.5f) {
				m_playerRigidbody.MovePosition ((Vector2)transform.position + new Vector2 (h, v) * speed * Time.deltaTime);
				playerMoving = true;
				lastMove = new Vector2 (h, v);
				//isMoving = false;
			}

			animator.SetFloat ("WalkX", h);
			animator.SetFloat ("WalkY", v);
			animator.SetBool ("PlayerMoving", playerMoving);
			animator.SetFloat ("LastMoveX", lastMove.x);
			animator.SetFloat ("LastMoveY", lastMove.y);
		}
	}

    public void ResetSkillBoxDistance()
    {
        m_skillBox[0].transform.localPosition = new Vector3(0, m_radius);
        m_skillBox[1].transform.localPosition = new Vector3(m_radius, 0);
        m_skillBox[2].transform.localPosition = new Vector3(0, -m_radius);
        m_skillBox[3].transform.localPosition = new Vector3(-m_radius, 0);
    }

    public static GameObject GetPlayerObject()
    {
        return _player;
    }

	public bool GetSoldier(Profession profession)
	{
		for (int i = 0; i < m_skillBox.Length; i++)
		{
			if(!m_skillBox[i].m_isOn)
			{
                m_skillBox[i].Init(profession);
                //m_skillBox[i].Init(profession, (Direction)i);
                return true;
			}
		}

		return false;
	}

	private Direction GetNextDirection(bool isRight)
	{
		int dirNum = (int)m_targetKey;

		if(isRight)
		{
			dirNum += 1;
			if (dirNum > (int)Direction.Left)
			{
				dirNum -= (int)Direction.Max;
			}
		}
		else
		{
			dirNum -= 1;
			if (dirNum < (int)Direction.Up)
			{
				dirNum += (int)Direction.Max;
			}
		}

		return (Direction)dirNum;
	}

	private void ResetSkillBoxDic(Direction targetKey)
	{
		if (targetKey == Direction.Up)
		{
            m_skillBox[0].SetDirection(Direction.Up);
            m_skillBox[1].SetDirection(Direction.Right);
            m_skillBox[2].SetDirection(Direction.Down);
            m_skillBox[3].SetDirection(Direction.Left);

            m_skillBoxDic[Direction.Up] = m_skillBox[0];
            m_skillBoxDic[Direction.Right] = m_skillBox[1];
            m_skillBoxDic[Direction.Down] = m_skillBox[2];
            m_skillBoxDic[Direction.Left] = m_skillBox[3];
        }
		else if (targetKey == Direction.Right)
		{
            m_skillBox[3].SetDirection(Direction.Up);
            m_skillBox[0].SetDirection(Direction.Right);
            m_skillBox[1].SetDirection(Direction.Down);
            m_skillBox[2].SetDirection(Direction.Left);

            m_skillBoxDic[Direction.Up] = m_skillBox[3];
            m_skillBoxDic[Direction.Right] = m_skillBox[0];
            m_skillBoxDic[Direction.Down] = m_skillBox[1];
            m_skillBoxDic[Direction.Left] = m_skillBox[2];
        }
		else if (targetKey == Direction.Down)
		{
            m_skillBox[2].SetDirection(Direction.Up);
            m_skillBox[3].SetDirection(Direction.Right);
            m_skillBox[0].SetDirection(Direction.Down);
            m_skillBox[1].SetDirection(Direction.Left);

            m_skillBoxDic[Direction.Up] = m_skillBox[2];
			m_skillBoxDic[Direction.Right] = m_skillBox[3];
			m_skillBoxDic[Direction.Down] = m_skillBox[0];
			m_skillBoxDic[Direction.Left] = m_skillBox[1];
		}
		else if (targetKey == Direction.Left)
		{
            m_skillBox[1].SetDirection(Direction.Up);
            m_skillBox[2].SetDirection(Direction.Right);
            m_skillBox[3].SetDirection(Direction.Down);
            m_skillBox[0].SetDirection(Direction.Left);

            m_skillBoxDic[Direction.Up] = m_skillBox[1];
			m_skillBoxDic[Direction.Right] = m_skillBox[2];
			m_skillBoxDic[Direction.Down] = m_skillBox[3];
			m_skillBoxDic[Direction.Left] = m_skillBox[0];
		}
	}

	private void InitCurrentPosition()
	{
		m_currentPosition.Add(Direction.Up, Vector3.up * m_radius);
		m_currentPosition.Add(Direction.Down, Vector3.down * m_radius);
		m_currentPosition.Add(Direction.Left, Vector3.left * m_radius);
		m_currentPosition.Add(Direction.Right, Vector3.right * m_radius);


		m_skillBoxDic.Add(Direction.Up, m_skillBox[0]);
		m_skillBoxDic.Add(Direction.Right, m_skillBox[1]);
		m_skillBoxDic.Add(Direction.Down, m_skillBox[2]);
		m_skillBoxDic.Add(Direction.Left, m_skillBox[3]);
	}



	private bool NeedToRotate()
	{
		Vector3 m_targetSkillBox = m_skillBox[0].transform.localPosition;
		Vector3 m_currectSkillBox = m_currentPosition[m_targetKey];
		float lenth = Vector3.Distance(m_targetSkillBox, m_currectSkillBox);
		if (lenth > m_Distance)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public static Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
	{
		return angle * (point - pivot) + pivot;
	}



}