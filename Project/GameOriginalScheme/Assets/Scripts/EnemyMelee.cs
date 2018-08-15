using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMelee : MonoBehaviour {

    public int damage = 10;
    public float attackRadius = 2;
    public float checkRadius = 10;
	public LayerMask checkLayers;
	public float enemySpeed;
	private Rigidbody2D enemy;
	private float closetDist;
	public GameObject meleeAttack;
	private bool enemyMoving;
	private Vector2 lastMove;
	private bool enemyAttack;
	private Vector2 attackDir;
	Animator animator;
	GameObject player;

	// Use this for initialization
	void Start () {
		enemy = this.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponentInChildren<Animator> ();
		//meleeAttack = GameObject.GetComponent <MeleeAttack> ();
		player = GameController.instance.Player;
        //meleeAttack.GetComponent<MeleeAttack> ().soundName = "laserKnife";
    }
	
	// Update is called once per frame
	void Update () {
		FindClosestEnemy ();
	}

	void FindClosestEnemy() {
		float distanceToClosestPlayer = Mathf.Infinity;
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, checkRadius, checkLayers);
		Collider2D closestPlayer = null;

		foreach (Collider2D player in colliders)
        {
			float distanceToPlayer = (player.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToPlayer < distanceToClosestPlayer) {
				distanceToClosestPlayer = distanceToPlayer;
				closestPlayer = player;
			}
		}

		if (closestPlayer != null) {
			Vector2 dir = (closestPlayer.transform.position - transform.position).normalized;
			Vector2 targetPos = enemy.position + dir * enemySpeed * Time.deltaTime;
			enemy.MovePosition (targetPos);
			float disToTarget = Vector2.Distance (closestPlayer.transform.position, this.transform.position);
			if (disToTarget < attackRadius)
            {
				enemyAttack = true;
				//meleeAttack.GetComponent<MeleeAttack> ().Attack ();

			} else {
				enemyAttack = false;
			}

			if (dir.x > 0.5f || dir.x < -0.5f) {
				enemyMoving = true;
				lastMove = new Vector2 (dir.x, 0f);
				//attackDir = new Vector2 (dir.x, 0f);
			}

			if (dir.y > 0.5f || dir.y < -0.5f) {
				enemyMoving = true;
				lastMove = new Vector2 (0f, dir.y);
				//attackDir = new Vector2 (0f, dir.y);
			}

			//if (enemyMoving == false) {
			//	attackDir = lastMove;
			//}
		
			animator.SetFloat ("WalkX", dir.x);
			animator.SetFloat ("WalkY", dir.y);
            animator.SetBool("EnemyMoving", enemyMoving);
            if (enemyAttack)
            {
                animator.SetTrigger("EnemyAttack");
            }
            
			//animator.SetBool ("EnemyMoving", enemyMoving);
			//animator.SetBool ("EnemyAttack", enemyAttack);
			//animator.SetFloat ("LastMoveX", lastMove.x);
			//animator.SetFloat ("LastMoveY", lastMove.y);  
			//animator.SetFloat ("AttackX", attackDir.x);
			//animator.SetFloat ("AttackY", attackDir.y); 
			Debug.DrawLine (this.transform.position, closestPlayer.transform.position);
		} 
	}

    public void EnemyMeleeDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius, checkLayers);

        foreach (Collider2D player in colliders)
        {
            player.GetComponent<CharacterHealth>().TakeDamage(damage);
        }

    }

	private void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, checkRadius);
	}



}
