using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {


    public float speed = 5;
	public float damage;
	private float timeBtwAttack;
	public float timeDuration = 3f;

	public Transform attackPos;
	public LayerMask enemies;
	public float attackRange;
    public Rigidbody2D m_rigidbody;

	void Start () 
    {
        m_rigidbody.velocity = this.transform.up * speed;
        timeBtwAttack = timeDuration;
    }
	
	void Update () 
    {
		if (timeBtwAttack <= 0) 
        {
            Destroy (gameObject);
		}
        else 
        {
			timeBtwAttack -= Time.deltaTime;
		}
    }

	void OnDrawGizmosSelected() 
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}

	void OnTriggerEnter2D (Collider2D other)
    {
		if (other.tag == "Enemy" || other.tag == "Boss" /*|| other.tag == "King"*/)
        {
            other.GetComponent<CharacterHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Bar")
        {
            other.GetComponent<MachineTrigger>().StateChange();
            Destroy(gameObject);
        }
        //		enemiesToDamage [i].GetComponent<CharacterHealth> ().TakeDamage (damage);
        //	}else {
        //		enemiesToDamage [i].GetComponent<MachineTrigger> ().StateChange ();
        //	}
        //Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (attackPos.position, attackRange, enemies);
        //for (int i = 0; i < enemiesToDamage.Length; i++) 
        //            {
        //	if (enemiesToDamage[i].tag != "Bar") {
        //		enemiesToDamage [i].GetComponent<CharacterHealth> ().TakeDamage (damage);
        //	}else {
        //		enemiesToDamage [i].GetComponent<MachineTrigger> ().StateChange ();
        //	}
        //	Destroy (gameObject);
        //}
    }


}
