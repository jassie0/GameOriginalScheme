using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public SoldierAnim m_soldierAnim;
    public AudioSource m_attackSource;
    public SpriteRenderer m_attackRange;
	private float timeBtwAttack;
	public float startTime;

	public Transform attackPos;
	public LayerMask enemies;
    public float damage;
	public float attackRange;
	public float hitForce = 1;
	private GameObject player;

	void Start () 
    {
		player = PlayerController.GetPlayerObject();
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

        timeBtwAttack = startTime;

        //SoundManager.Instance().PlaySound("laserKnife");
    }


    public void Attack(Direction dir)
    {
        if(timeBtwAttack > 0)
        {
            return;
        }

       // SoundManager.Instance().PlaySound("soldierAttack");

        if (m_soldierAnim != null)
        {
            m_soldierAnim.AttackAnim(dir);
        }

        timeBtwAttack = startTime;
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

    public void TakeDamage()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if (enemiesToDamage[i].tag != "Bar")
            {
                CharacterHealth characterHealth = enemiesToDamage[i].GetComponent<CharacterHealth>();
                if (characterHealth != null)
                {
                    characterHealth.TakeDamage(damage);
                }

                if (enemiesToDamage[i].tag == "Hand")
                {

                }
            }
            else
            {
                MachineTrigger machineTrigger = enemiesToDamage[i].GetComponent<MachineTrigger>();
                if (machineTrigger != null)
                {
                    machineTrigger.StateChange();
                }
            }

			Vector2 pushDir =   enemiesToDamage[i].transform.position - transform.position;
			pushDir =- pushDir.normalized;
			if (enemiesToDamage [i].tag == "Enemy") {
				//Debug.Log ("back");
				enemiesToDamage [i].GetComponent<Rigidbody2D> ().AddForce (-pushDir * hitForce * 100000000);
            }

        }

        //StartCoroutine(SetAttackRange());
    }

}
