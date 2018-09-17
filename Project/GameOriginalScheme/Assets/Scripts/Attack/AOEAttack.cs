using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour {

    public SoldierAnim m_soldierAnim;
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
    private SpriteRenderer m_spriteRenderer;

    void Start () {
        if(m_attackRange != null)
        {
            m_attackRange.gameObject.SetActive(false);
        }

        m_spriteRenderer = charSprite.GetComponent<SpriteRenderer>();
        m_spriteRenderer.material = outlineMaterial;
	}
	
	void Update () {

        if(coolDownTime < 0)
        {
            return;
        }

        if (coolDownTime > 0)
        {
            coolDownTime -= Time.deltaTime;
            if(m_spriteRenderer.material != defaultMaterial)
            {
                m_spriteRenderer.material = defaultMaterial;
            }

        }
		else 
        {
            if(m_spriteRenderer.material != outlineMaterial)
            {
                m_spriteRenderer.material = outlineMaterial;
            }

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

        coolDownTime = startTime;
       
        RotateAroundPivot(direction, transform);

        SoundManager.Instance().PlaySound("generalAttack");

        if(m_soldierAnim != null)
        {
            m_soldierAnim.AttackAnim(m_direction);
        }

    }

    public void TakeAttackRange()
    {
        charSprite.GetComponent<SpritesOutline>().outlineSize = 16;
        Collider2D[] enemiesToDamage = Physics2D.OverlapAreaAll(startPos.position, endPos.position, enemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
			if (enemiesToDamage[i].tag == "Player" || enemiesToDamage[i].tag == "King" || enemiesToDamage[i].tag == "Boss" || 
            enemiesToDamage[i].tag == "Hand" || enemiesToDamage[i].tag == "Enemy" ) 
            {
                CharacterHealth characterHealth = enemiesToDamage [i].GetComponent<CharacterHealth> ();
                if(characterHealth != null)
                {
                    characterHealth.TakeDamage (damage);
                }
			} 
            else if (enemiesToDamage[i].tag == "Bar") 
            {
                MachineTrigger machineTrigger = enemiesToDamage [i].GetComponent<MachineTrigger> ();
                if(machineTrigger != null)
                {
                    machineTrigger.StateChange ();
                }
			} 
            else if (enemiesToDamage[i].tag == "Breakable") 
            {
                BreakableWall breakableWall = enemiesToDamage [i].GetComponent<BreakableWall> ();
                if(breakableWall != null)
                {
                    breakableWall.WallChange ();
                }
			}
        }

        coolDownTime = startTime;
    }


    IEnumerator SetAttackRange()
    {
        if(m_attackRange != null)
        {
            m_attackRange.gameObject.SetActive(true);
        }
        
        yield return new WaitForSeconds(0.2f);

        if(m_attackRange != null)
        {
            m_attackRange.gameObject.SetActive(false);
        }
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
        }
        else if (direction == Direction.Left)
        {
            transform.rotation = Quaternion.Euler(0, 0, -270);
        }
    }
}
