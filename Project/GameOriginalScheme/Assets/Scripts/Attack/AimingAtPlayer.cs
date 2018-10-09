using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingAtPlayer : MonoBehaviour {
    public Transform target;
    public float attackRange;
    public float attackDelay;
    public float damage;
    public float gunTurnRate;
    public float bulletForce;
    public GameObject bulletPrefab;
    public LayerMask layerMask;
    public GameObject gunBarrel;
    public GameObject enemyBody;
    public float bulletInterval;
    public int bulletCount;

    private float timeBtwAttack;
    private LineRenderer lr;
    private float alpha = 0;
    private bool checkShoot = true;

    // Use this for initialization
    void Start () {
        target = PlayerController.GetPlayerObject().transform;
        lr = gunBarrel.GetComponent<LineRenderer>();
        timeBtwAttack = 0;
    }
	
	// Update is called once per frame
	void Update () {
        lr.materials[0].SetColor("_TintColor", new Color(0.75f, 0, 0, Mathf.Lerp(0, 1.0f, alpha)));
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange) {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, gunTurnRate * Time.deltaTime);

           // if (Time.time > lastAttackTime + attackDelay) {
                
            RaycastHit2D hit = Physics2D.Raycast(gunBarrel.transform.position, gunBarrel.transform.up, attackRange, layerMask);

            if (hit.collider != null)
            {
                lr.SetPosition(1, new Vector3(0, hit.distance+0.2f, 0));
                if (hit.collider.tag == "King" || hit.collider.tag == "Player")
                {   

                    if (timeBtwAttack <= 0)
                    {
                        if (alpha < 1.0f)
                        {
                            alpha += Time.deltaTime / 2f;
                        } else {
                            if (checkShoot == true)
                            {
                                StartCoroutine(LaunchBullets());
                                enemyBody.GetComponent<EnemyShooter>().enemyAttack = true;
                                checkShoot = false;
                            }
                            alpha = 0;
                            timeBtwAttack = attackDelay;
                            checkShoot = true;
                        }
                       
                    } else {
                        timeBtwAttack -= Time.deltaTime;
                    }
                }
            }
        }
	}

    IEnumerator LaunchBullets() {
        int n = 0;
        while (n < bulletCount) {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));          
            yield return new WaitForSeconds(bulletInterval);
            n++;          
        }
    }
}
