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
	public float hitForce = 1;
	//public string soundName;
	private GameObject player;

	void Start () 
    {
		player = GameObject.Find ("King");
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
			Vector2 pushDir =   enemiesToDamage[i].transform.position - transform.position;
			pushDir =- pushDir.normalized;
			Debug.Log (pushDir);
			if (enemiesToDamage [i].tag == "Player" ) {
				player.GetComponent<Rigidbody2D> ().AddForce (-pushDir * hitForce * 100000000);
			}
        }

        timeBtwAttack = startTime;

//        if (m_attackSource != null)
//        {
//            m_attackSource.Play();
//        }
		SoundManager.PlaySound("laserKnife");

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
			if (enemiesToDamage[i].tag != "Device") {
				enemiesToDamage [i].GetComponent<CharacterHealth> ().TakeDamage (damage);
			}else {
				enemiesToDamage [i].GetComponent<PullBar> ().StateChange ();
			}

        }

        timeBtwAttack = startTime;

//        if (m_attackSource != null)
//        {
//            m_attackSource.Play();
//        }
		SoundManager.PlaySound("soldierAttack");

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
