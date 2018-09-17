using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttack : MonoBehaviour {

    public Animator m_bingAni;
    public AudioSource m_attackSource;
    public GameObject m_attackRange;
    private float coolDownTime;
    private float startTime;
    public LayerMask enemies;
    public float damage;
    public float duringTime = 1.5f;
    public SoldierAnim m_soldierAnim;

    private Direction m_direction = Direction.Up;

    void Start()
    {
        m_attackRange.gameObject.SetActive(false);
    }

    void Update()
    {
        if (coolDownTime > 0)
        {
            coolDownTime -= Time.deltaTime;
        }
    }

    public void SetDirection(Direction direction)
    {
        m_direction = direction;
    }

    public void Attack(Direction direction)
    {
        if (coolDownTime > 0)
        {
            return;
        }

        RotateAroundPivot(direction, transform);

        SoundManager.Instance().PlaySound("generalAttack");

        TakeAttackRange();
    }

    public void TakeAttackRange()
    {
        coolDownTime = startTime;

        StartCoroutine(SetAttackRange());
    }

    IEnumerator SetAttackRange()
    {
        if(m_soldierAnim != null)
        {
            m_soldierAnim.AttackAnim(m_direction);
        }
        m_attackRange.gameObject.SetActive(true);
        yield return new WaitForSeconds(duringTime);
        m_attackRange.gameObject.SetActive(false);
    }

    public void RotateAroundPivot(Direction direction, Transform nubing)
    {
        if (direction == Direction.Up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Direction.Right)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (direction == Direction.Down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if (direction == Direction.Left)
        {
            transform.rotation = Quaternion.Euler(0, 0, -270);
        }
    }
}
