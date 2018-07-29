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
	public string hurtSoundName;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		healthPercent = health/maxHealth;
		healthBar.localScale = new Vector3 (healthPercent * barOriginScale,1 ,1);
		if (health <= 0 ) {
            SoundManager.PlaySound("soilderDie");
            SkillBox skillBox = this.GetComponentInParent<SkillBox>();
            if(skillBox != null)
            {
                skillBox.Relese();
            }

			Destroy (gameObject);
		}
	}

	public void TakeDamage (float damage) {
        
		health -= damage;
        if (m_hurtSource != null)
        {
			SoundManager.PlaySound (hurtSoundName);
        }
		//Debug.Log ("aaaa");
	}
}
