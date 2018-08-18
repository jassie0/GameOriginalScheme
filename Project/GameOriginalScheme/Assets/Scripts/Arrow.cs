using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {


    public float speed = 5;
	public float damage;
	private float timeBtwAttack;
	public float startTime;

	public Transform attackPos;
	public LayerMask enemies;
	public float attackRange;
	public bool hurtEnemy;
    public Rigidbody2D m_rigidbody;

	void Start () 
    {
        m_rigidbody.velocity = this.transform.up * speed;
    }
	
	void Update () 
    {
		if (speed > 0 && hurtEnemy == true) 
        {
			if (timeBtwAttack <= 0) 
            {
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (attackPos.position, attackRange, enemies);
				for (int i = 0; i < enemiesToDamage.Length; i++) 
                {
					if (enemiesToDamage[i].tag != "Device") {
						enemiesToDamage [i].GetComponent<CharacterHealth> ().TakeDamage (damage);
					}else {
						enemiesToDamage [i].GetComponent<PullBar> ().StateChange ();
					}
				}
				Destroy (gameObject);
				timeBtwAttack = startTime;
			} else 
            {
				timeBtwAttack -= Time.deltaTime;
			}
		}

    }

	void OnDrawGizmosSelected() 
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}

	void OnTriggerEnter2D (Collider2D other)
    {
		if (other.tag == "Enemy") {
			hurtEnemy = true;
		}
	}


}
