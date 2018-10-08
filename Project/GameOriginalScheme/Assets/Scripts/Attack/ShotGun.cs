using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour {
    public Transform target;
    public float attackRange;
    public float attackDelay;
    public float damage;
    public float gunTurnRate;
    public float bulletForce;
    public GameObject bulletPrefab;
    public int bulletNum;
    public float angleBtwBullets;
    public LayerMask layerMask;

    private float lastAttackTime;
    public Transform[] childGun;


    // Use this for initialization
    void Start()
    {
        target = PlayerController.GetPlayerObject().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, gunTurnRate * Time.deltaTime);

            if (Time.time > lastAttackTime + attackDelay)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange, layerMask);

                if (hit.collider != null) {
                    GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    //newBullet.transform.parent = gameObject.transform;
                    newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                    foreach (Transform b in childGun) {
                        GameObject otherBullet = Instantiate(bulletPrefab, b.position, b.rotation);
                        otherBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                        //otherBullet.transform.parent = b;
                    }
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
