using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnim : MonoBehaviour {

	public GameObject m_soldier;
	PlayerController playerController;
	Animator animator;
	// Use this for initialization
	void Start () {
		//player = GameController.instance.Player;
        playerController = PlayerController.GetPlayerObject().GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("WalkX", Input.GetAxisRaw("Horizontal"));
		animator.SetFloat ("WalkY", Input.GetAxisRaw("Vertical"));
		animator.SetBool ("PlayerMoving", playerController.playerMoving);
		animator.SetFloat ("LastMoveX", playerController.lastMove.x);
		animator.SetFloat ("LastMoveY", playerController.lastMove.y);     
	}

	void DistoryThisAfterDeath()
	{
		if(m_soldier != null)
		{
			gameObject.SetActive(false);
		}
	}

	public void SetDieAnim()
	{
		animator.SetBool("Dead", true);
	}

	public void AttackAnim(Direction curDirection)
	{
        switch (curDirection)
        {
            case Direction.Up:
            {
                animator.SetFloat("AttackX", 0f);
                animator.SetFloat("AttackY", 1f);
                break;
            }
            case Direction.Right:
            {
                animator.SetFloat("AttackX", 1f);
                animator.SetFloat("AttackY", 0f);
                break;
            }
            case Direction.Down:
            {
                animator.SetFloat("AttackX", 0f);
                animator.SetFloat("AttackY", -1f);
                break;
            }
            case Direction.Left:
            {
                animator.SetFloat("AttackX", -1f);
                animator.SetFloat("AttackY", 0f);
                break;
            }
        }

        animator.SetTrigger("Attacking");
		
	}
}
