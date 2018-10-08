using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour {

    public int bulletNum;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public float spreadAngle;
    

    private Vector2 startPoint;
    private Vector2 targetPos;
    private const float radius = 1f;

    // Use this for initialization
    void Start () {
        targetPos = PlayerController.GetPlayerObject().transform.position;
        startPoint = transform.position;
        SpawnBullet(bulletNum);
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void SpawnBullet(int _bulletNum) {
        float angleStep = spreadAngle / _bulletNum;
        float angle = 0f;
        
        for (int i = 0; i < _bulletNum; i++) {
           float bulletDirXPos = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
           float bulletDirYPos = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
            Vector2 bulletVector = new Vector2(bulletDirXPos, bulletDirYPos);
            Vector2 bulletDir = (bulletVector - startPoint).normalized * bulletSpeed;

            GameObject tmpObj = Instantiate(bulletPrefab, transform.parent.position, transform.parent.rotation);
            tmpObj.transform.parent = gameObject.transform;
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDir.x, bulletDir.y);

            angle += angleStep;
        }
    }
}
