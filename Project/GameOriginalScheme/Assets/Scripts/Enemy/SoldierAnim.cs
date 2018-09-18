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
		animator.SetFloat ("WalkX", playerController.h);
		animator.SetFloat ("WalkY", playerController.v);
		animator.SetBool ("PlayerMoving", PlayerController.GetPlayerObject().GetComponent<PlayerController>().playerMoving);
		animator.SetFloat ("LastMoveX", PlayerController.GetPlayerObject().GetComponent<PlayerController>().lastMove.x);
		animator.SetFloat ("LastMoveY", PlayerController.GetPlayerObject().GetComponent<PlayerController>().lastMove.y);     
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
