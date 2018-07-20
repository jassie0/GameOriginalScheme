using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public Animator m_bingAni;
    public AudioSource m_attackSource;
    public SpriteRenderer m_attackRange;
	private float timeBtwAttack;
	public float startTime;

	public Transform attackPos;
	public LayerMask enemies;
    public float damage;
	public float attackRange;

	void Start () 
    {

	}
	
	void Update () 
    {
        if(timeBtwAttack > -10)
        {
            timeBtwAttack -= Time.deltaTime;
        }
		
	}


    public void Attack()
    {
        if (timeBtwAttack > 0)
        {
            return;
        }

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<CharacterHealth>().TakeDamage(damage);
        }

        timeBtwAttack = startTime;

        if (m_attackSource != null)
        {
            m_attackSource.Play();
        }


        StartCoroutine(SetAttackRange());
    }


    public void Attack(Direction dir)
    {
        if(timeBtwAttack > 0)
        {
            return;
        }

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<CharacterHealth>().TakeDamage(damage);
        }

        timeBtwAttack = startTime;

        if (m_attackSource != null)
        {
            m_attackSource.Play();
        }

        if (m_bingAni)
        {
            PlayAnimation(dir);
        }

        StartCoroutine(SetAttackRange());
    }

	void OnDrawGizmosSelected() 
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}

    IEnumerator SetAttackRange()
    {
        if(m_attackRange == null)
        {
            yield break;
        }
        m_attackRange.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
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
}
