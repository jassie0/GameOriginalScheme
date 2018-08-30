using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttack : MonoBehaviour {

    public Animator m_bingAni;
    public AudioSource m_attackSource;
    public SpriteRenderer m_attackRange;
    private float coolDownTime;
    private float startTime;
    public LayerMask enemies;
    public float damage;
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
        m_attackRange.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        m_attackRange.gameObject.SetActive(false);
    }

    public void PlayAnimation(Direction curDirection)
    {
        //Direction curDirection = GetCurrectDirection(m_defaultDirection, dir);


        if (curDirection == Direction.Up)
        {
            m_bingAni.SetFloat("AttackDirection", 0.66f);
        }
        else if (curDirection == Direction.Right)
        {
            m_bingAni.SetFloat("AttackDirection", 1f);
        }
        else if (curDirection == Direction.Down)
        {
            m_bingAni.SetFloat("AttackDirection", 0.0f);
        }
        else if (curDirection == Direction.Left)
        {
            m_bingAni.SetFloat("AttackDirection", 0.33f);
        }

        m_bingAni.SetTrigger("Attacking");

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
