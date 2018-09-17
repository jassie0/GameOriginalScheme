using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    public AudioSource m_hurtSource;
	public float health;
	public float maxHealth;
	public float healthPlus;
	public float originalHealth;
	public float healthPercent;
	public float maskOriginScale;
	public float maskYScale;
	//public string hurtSoundName;
	// Use this for initialization
	public SpriteRenderer characterSprite;
	public Transform barMask;

	public bool invincible = false;

	static readonly float invincilityTime = 1f;
	static readonly float flickerTime = 0.1f;

    public float HealthPrecent { get { return healthPercent; } }

	public bool EnemyGetHit;
	public bool EnemyExplode;
	public bool EnemyDie = false;
	public Transform enemyHurtAnim;
	public Transform enemyExplodeAnim;


	public GameObject coinSpawnPrefab;
	public SoldierAnim m_soldierAnim;

    void Start () {
		health = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		healthPercent = health/maxHealth;
		barMask.localScale = new Vector3 (healthPercent * maskOriginScale, maskYScale ,1);
		if (health <= 0 ) {

			if(EnemyDie == true)
			{
				return;
			}

            if(gameObject.tag == "King")
            {
                UIControl.Instance().SetGameOver(false);
            }

            //无尽模式刷新计分板
            if(gameObject.layer == 9)
            {
                UIControl.Instance().EnemyDeadScore();
            }

            
            SkillBox skillBox = this.GetComponentInParent<SkillBox>();
            if(skillBox != null)
            {
                skillBox.Relese();
            }

            if (gameObject.tag == "Player")
			{
				StartCoroutine(SoldierGoToHell());
			} else if (gameObject.tag == "Enemy")
			{
				StartCoroutine(EnemyGoToHell ());
			}

			EnemyDie = true;
        }
	}

	public void TakeDamage (float damage) {
        
		if (!invincible) {
			health -= damage;
			
			if (gameObject.tag == "King") {
                SoundManager.Instance().PlaySound ("kingActHurt");
			} else if (gameObject.tag == "Player"){
                SoundManager.Instance().PlaySound ("soldierActHurt");
			} else if (gameObject.tag == "Enemy"){
				if (health > 0) {
					Transform hurtAnim = Instantiate(enemyHurtAnim, transform.position, enemyHurtAnim.rotation, this.transform.parent);
					hurtAnim.parent = transform;
				}
				SoundManager.Instance().PlaySound ("hitEnemy");

			}

			if (health > 0 && gameObject.tag == "Player" || gameObject.tag == "King") {
				StartCoroutine (Flash());
			}
		}
	}

	IEnumerator Flash() {
		float time = 0f;

		bool showSprite = false;

		invincible = true;
		while (time < invincilityTime) {
			characterSprite.enabled = showSprite;

			yield return new WaitForSeconds (flickerTime);
			showSprite = !showSprite;

			time = time + flickerTime;
		}

		characterSprite.enabled = true;

		invincible = false;
	}

	IEnumerator EnemyGoToHell () {
		Transform explodeAnim = Instantiate(enemyExplodeAnim, transform.position, enemyExplodeAnim.rotation, this.transform.parent);
		explodeAnim.parent = transform;
		SoundManager.Instance().PlaySound("soilderDie");
		yield return null;
	} 
		
	IEnumerator SoldierGoToHell()
	{
		if(m_soldierAnim != null)
		{
			m_soldierAnim.SetDieAnim();
			SoundManager.Instance().PlaySound("soilderDie");
		}
		yield return new WaitForSeconds (1f);
		
		Destroy(gameObject);
	}
}
