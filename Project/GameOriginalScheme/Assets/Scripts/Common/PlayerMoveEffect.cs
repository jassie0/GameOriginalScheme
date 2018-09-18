using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveEffect : MonoBehaviour {
    public GameObject WalkDownEffect;
    public GameObject WalkUpEffect;
    public GameObject WalkLeftEffect;
    public GameObject WalkRightEffect;

    void WalkDown() {
        WalkDownEffect.SetActive(true);
        WalkUpEffect.SetActive(false);
        WalkLeftEffect.SetActive(false);
        WalkRightEffect.SetActive(false);
    }

    void WalkUp()
    {
        WalkDownEffect.SetActive(false);
        WalkUpEffect.SetActive(true);
        WalkLeftEffect.SetActive(false);
        WalkRightEffect.SetActive(false);
    }

    void WalkLeft()
    {
        WalkDownEffect.SetActive(false);
        WalkUpEffect.SetActive(false);
        WalkLeftEffect.SetActive(true);
        WalkRightEffect.SetActive(false);
    }

    void WalkRight()
    {
        WalkDownEffect.SetActive(false);
        WalkUpEffect.SetActive(false);
        WalkLeftEffect.SetActive(false);
        WalkRightEffect.SetActive(true);
    }

    void Idle()
    {
        WalkDownEffect.SetActive(false);
        WalkUpEffect.SetActive(false);
        WalkLeftEffect.SetActive(false);
        WalkRightEffect.SetActive(false);
    }
}
