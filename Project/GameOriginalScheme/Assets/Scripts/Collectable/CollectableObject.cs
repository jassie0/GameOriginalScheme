using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableObject : MonoBehaviour
{
    public int CollectableNum;
   // public GameObject leanTouch;

    // Use this for initialization
    void Start()
    {
        //CollectionCount.Collections = new List<bool>();
        //if (CurrentCollection != LoadGame.CollectionState)
        //{
        //    CurrentCollection = LoadGame.CollectionState;
        //}

        if (CollectionCount.CurrentCollection[CollectableNum] == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "King")
        {
            CollectionCount.CurrentCollection[CollectableNum] = true;
            CollectionCount.Collection[CollectableNum] = true;

            gameObject.SetActive(false);
        }
    }






}
