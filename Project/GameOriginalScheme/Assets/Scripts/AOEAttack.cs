using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour {

    public Animator m_bingAni;
    public AudioSource m_attackSource;
    public SpriteRenderer m_attackRange;
	public float coolDownTime;

	public float startTime;

	public Transform startPos;
	public Transform endPos;
	public LayerMask enemies;
	public float damage;
	// Use this for initialization
	void Start () {
        m_attackRange.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (coolDownTime > -20)
        {
            coolDownTime -= Time.deltaTime;
        }
		else 
        {
			coolDownTime -= Time.deltaTime;
		} 
	}

    public void Attack(Direction dir)
    {
        if (coolDownTime > 0)
        {
            return;
        }

        Collider2D[] enemiesToDamage = Physics2D.OverlapAreaAll(startPos.position, endPos.position, enemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<CharacterHealth>().TakeDamage(damage);
        }
        coolDownTime = startTime;

        if (m_attackSource != null)
        {
            m_attackSource.Play();
        }
        if(m_bingAni)
        {
            PlayAnimation(dir);
        }

        StartCoroutine(SetAttackRange());
    }

    IEnumerator SetAttackRange()
    {
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
