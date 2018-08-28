using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    public AudioSource m_hurtSource;
	public float health;
	public float maxHealth;
	public Transform healthBar;
	public float healthPercent;
	public float barOriginScale;
	//public string hurtSoundName;
	// Use this for initialization
	public SpriteRenderer characterSprite;

	public bool invincible = false;

	static readonly float invincilityTime = 1f;
	static readonly float flickerTime = 0.1f;

	void Start () {
		health = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		healthPercent = health/maxHealth;
		healthBar.localScale = new Vector3 (healthPercent * barOriginScale,1 ,1);
		if (health <= 0 ) {

            if(gameObject.name == "King")
            {
                UIControl.instance.SetGameOver(false);
            }

            if(gameObject.layer == 9)
            {
                UIControl.instance.EnemyDeadScore();
            }

            SoundManager.instance.PlaySound("soilderDie");
            SkillBox skillBox = this.GetComponentInParent<SkillBox>();
            if(skillBox != null)
            {
                skillBox.Relese();
            }

			Destroy (gameObject);
		}
	}

	public void TakeDamage (float damage) {
        
		if (!invincible) {
			health -= damage;
			
			if (gameObject.tag == "King") {
                SoundManager.instance.PlaySound ("kingActHurt");
			} else {
                SoundManager.instance.PlaySound ("soldierActHurt");
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
}
