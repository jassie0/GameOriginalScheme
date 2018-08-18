using System.Collections;
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

public class PlayerController : MonoBehaviour 
{
    public Rigidbody2D m_playerRigidbody;
	public float speed;
	public float rotateSpeed;
	public GameObject moveDes;
   
	public SkillBox[] m_skillBox;
	public float angle = 1;
	public float m_radius = 2f;

	private bool isMoving;
	//private Vector3 target;
	private Direction m_targetKey = Direction.Up;
	private Dictionary<Direction, Vector3> m_currentPosition = new Dictionary<Direction, Vector3>();
	private const float m_Distance = 0.05f;
	private float m_rotateDirection = -1;//-1向右转， 1向左转
	private Dictionary<Direction, SkillBox> m_skillBoxDic = new Dictionary<Direction, SkillBox>();

	public bool playerMoving;
	public Vector2 lastMove;
	public bool deathFlag;





	//private Rigidbody2D playerRigidbody;

	public GameObject animSprite;
	Animator animator;

	void Awake()
	{
		InitCurrentPosition();
	}

	void Start()
	{
		Time.timeScale = 1;
		animator = animSprite.GetComponent<Animator> ();
        ResetSkillBoxDic(m_targetKey);
    }

	void FixedUpdate()
	{

        if (NeedToRotate())
        {
            for (int i = 0; i < m_skillBox.Length; i++)
            {
                m_skillBox[i].transform.position = RotateAroundPivot(m_skillBox[i].transform.position, transform.position, Quaternion.Euler(0, 0, angle * m_rotateDirection));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                m_targetKey = GetNextDirection(false);
                ResetSkillBoxDic(m_targetKey);
                m_rotateDirection = 1;

            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                m_targetKey = GetNextDirection(true);
                ResetSkillBoxDic(m_targetKey);
                m_rotateDirection = -1;
            }
        }

//		if (Input.GetMouseButtonDown(0))
//		{
//			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			//Debug.Log(Input.mousePosition);
//			target.z = transform.position.z;
//
//			if (isMoving == false)
//				isMoving = true;
//
//			Instantiate(moveDes, target, Quaternion.identity);
//		}

//
//		if (isMoving == true)
//		{
//			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
//		}

		playerMoving = false;

        /*替换移动逻辑
		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f){
            //transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw("Horizontal"), 0f);
			isMoving = false;
		}

		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical")< -0.5f) {
			//transform.Translate (new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			isMoving = false;
		}*/

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h > 0.5f || v > 0.5f || h < -0.5f || v < -0.5f)
        {
            m_playerRigidbody.MovePosition((Vector2)transform.position + new Vector2(h, v) * speed * Time.deltaTime);
            playerMoving = true;
            lastMove = new Vector2(h, v);
            isMoving = false;
        }
        




		if (Input.GetKeyDown(KeyCode.W))
		{
			SkillBox skillBox = m_skillBoxDic[Direction.Up];
			skillBox.UseSkill();

		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			SkillBox skillBox = m_skillBoxDic[Direction.Right];
			skillBox.UseSkill();
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			SkillBox skillBox = m_skillBoxDic[Direction.Down];
			skillBox.UseSkill();
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			SkillBox skillBox = m_skillBoxDic[Direction.Left];
			skillBox.UseSkill();
		}





		animator.SetFloat ("WalkX", h);
		animator.SetFloat ("WalkY", v);
		animator.SetBool ("PlayerMoving", playerMoving);
		animator.SetFloat ("LastMoveX", lastMove.x);
		animator.SetFloat ("LastMoveY", lastMove.y);     
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

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

}