using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovingEffect : MonoBehaviour {
    PlayerController playerController;
    Animator animator;
    private SpriteRenderer sprite;
    public GameObject soldierSprite;

    // Use this for initialization
    void Start () {
        playerController = PlayerController.GetPlayerObject().GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("WalkX", playerController.h);
        animator.SetFloat("WalkY", playerController.v);
        animator.SetBool("PlayerMoving", playerController.playerMoving);
        
    }

    void LayerFront() {
        if (playerController.v > 0) {
            sprite.sortingOrder = 4;

        }
    }

    void LayerBack() {
        if (playerController.v < 0) {
            sprite.sortingOrder = 2;
        }
        
    }

}

