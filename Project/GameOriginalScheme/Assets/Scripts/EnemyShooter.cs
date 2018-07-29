using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    public AudioSource shootSource;
	public float checkRadius;
	public LayerMask checkLayers;
	public float speed;
	private Rigidbody2D enemy;
	private float closetDist;
	public float attackRange;

	private float timeBtwShoot;
	public float startTime;
	public GameObject laserPrefab;
	public float laserSpeed;

	private bool enemyMoving;
	private Vector2 lastMove;
	private Vector2 attackDir;
	private bool enemyAttack;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponentInChildren<Animator> ();
		enemy = this.GetComponent<Rigidbody2D> ();
		//meleeAttack = GameObject.GetComponent <MeleeAttack> ();
		timeBtwShoot = startTime;

	}

	// Update is called once per frame
	void Update () {
		FindClosestEnemy ();
	}

	public void FindClosestEnemy() {
		float distanceToClosestPlayer = Mathf.Infinity;
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, checkRadius, checkLayers);
		Collider2D closestPlayer = null;

		foreach (Collider2D player in colliders) {
			float distanceToPlayer = (player.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToPlayer < distanceToClosestPlayer) {
				distanceToClosestPlayer = distanceToPlayer;
				closestPlayer = player;
			}
		}
		if (closestPlayer != null) {
			Vector2 dir = (closestPlayer.transform.position - transform.position).normalized;
			Vector2 targetPos = enemy.position + dir * speed * Time.deltaTime;
			enemy.MovePosition (targetPos);
			float disToTarget = Vector2.Distance (closestPlayer.transform.position, this.transform.position);
			//Debug.Log (disToTarget);

			if (disToTarget < attackRange) {
				speed = 0;
				transform.position = this.transform.position;
				if (timeBtwShoot <= 0) {	
					enemyAttack = true;
					Instantiate (laserPrefab, this.transform.position, Quaternion.identity);

					timeBtwShoot = startTime;

//					if (shootSource != null) {
//						shootSource.Play ();
//					}

					//SoundManager.PlaySound("laserGun");
					//laser.GetComponent<Arrow> ().speed = laserSpeed;
					//obj.transform.Rotate(closestPlayer.transform.position - transform.position);

				} else {
					timeBtwShoot -= Time.deltaTime;
				}
			} else {
				speed = 2;	
				enemyAttack = false;
			}

			if (dir.x > 0.5f || dir.x < -0.5f) {
				enemyMoving = true;
				lastMove = new Vector2 (dir.x, 0f);
				attackDir = new Vector2 (dir.x, 0f);
			}

			if (dir.y > 0.5f || dir.y < -0.5f) {
				enemyMoving = true;
				lastMove = new Vector2 (0f, dir.y);
				attackDir = new Vector2 (0f, dir.y);
			}

			if (enemyMoving == false) {
				attackDir = lastMove;
			}

			animator.SetFloat ("WalkX", dir.x);
			animator.SetFloat ("WalkY", dir.y);
			animator.SetBool ("EnemyMoving", enemyMoving);
			animator.SetBool ("EnemyAttack", enemyAttack);
			animator.SetFloat ("LastMoveX", lastMove.x);
			animator.SetFloat ("LastMoveY", lastMove.y);  
			animator.SetFloat ("AttackX", attackDir.x);
			animator.SetFloat ("AttackY", attackDir.y);  



			Debug.DrawLine (this.transform.position, closestPlayer.transform.position);
		}
	}



	private void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, checkRadius);
	}

}
