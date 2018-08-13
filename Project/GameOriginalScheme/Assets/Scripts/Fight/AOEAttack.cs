using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour {

    public Animator m_bingAni;
    public AudioSource m_attackSource;
    public SpriteRenderer m_attackRange;
	public float coolDownTime;

	public float startTime;

	public Transform startPos;
	public Transform endPos;
	public LayerMask enemies;
	public float damage;
    private Direction m_direction = Direction.Up;
	public GameObject charSprite;
	public Material defaultMaterial;
	public Material outlineMaterial;


	// Use this for initialization
	void Start () {
        m_attackRange.gameObject.SetActive(false);
		//charSprite.GetComponent<SpritesOutline> ().outlineSize = 16;
		charSprite.GetComponent<SpriteRenderer> ().material = outlineMaterial;
	}
	
	// Update is called once per frame
	void Update () {

        if (coolDownTime > 0)
        {
            coolDownTime -= Time.deltaTime;
			//charSprite.GetComponent<SpritesOutline> ().outlineSize = 0;
			charSprite.GetComponent<SpriteRenderer> ().material = defaultMaterial;
        }
		else 
        {
			//coolDownTime -= Time.deltaTime;
			//charSprite.GetComponent<SpritesOutline> ().outlineSize = 16;
			charSprite.GetComponent<SpriteRenderer> ().material = outlineMaterial;
		} 
	}

    public void SetDirection(Direction direction)
    {
        m_direction = direction;
    }

    public void Attack(Direction direction)
    {
		if (coolDownTime > 0) {
			return;
		} 
        RotateAroundPivot(direction, transform);

		charSprite.GetComponent<SpritesOutline> ().outlineSize = 16;
		Collider2D[] enemiesToDamage = Physics2D.OverlapAreaAll (startPos.position, endPos.position, enemies);

		for (int i = 0; i < enemiesToDamage.Length; i++) {
			enemiesToDamage [i].GetComponent<CharacterHealth> ().TakeDamage (damage);
		}

		coolDownTime = startTime;


        //        if (m_attackSource != null)
        //        {
        //            m_attackSource.Play();
        //        }
        CGame.Instance.SoundSystem.PlaySound("generalAttack");

        if(m_bingAni)
        {
            PlayAnimation(m_direction);
        }

        StartCoroutine(SetAttackRange());
    }

    IEnumerator SetAttackRange()
    {
        m_attackRange.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        m_attackRange.gameObject.SetActive(false);
    }

    public void PlayAnimation(Direction curDirection)
    {
        //Direction curDirection = GetCurrectDirection(m_defaultDirection, dir);


        if (curDirection == Direction.Up)
        {
            m_bingAni.SetFloat("AttackDirection", 0.66f);
        }
        else if (curDirection == Direction.Right)
        {
            m_bingAni.SetFloat("AttackDirection", 1f);
        }
        else if (curDirection == Direction.Down)
        {
            m_bingAni.SetFloat("AttackDirection", 0.0f);
        }
        else if (curDirection == Direction.Left)
        {
            m_bingAni.SetFloat("AttackDirection", 0.33f);
        }

        m_bingAni.SetTrigger("Attacking");

    }

    public void RotateAroundPivot(Direction direction, Transform nubing)
    {
        if (direction == Direction.Up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Direction.Right)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (direction == Direction.Down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -180);
            //nubing.Rotate(0, 0, -180);
        }
        else if (direction == Direction.Left)
        {
            transform.rotation = Quaternion.Euler(0, 0, -270);
            //nubing.Rotate(0, 0, -270);
        }
    }
}
