using UnityEngine;
using System.Collections;

public class LayerController : MonoBehaviour
{
	void Start ()
    {
        if (gameObject.tag == "Wall")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        }
    }
	
	void Update ()
    {
        if (gameObject.tag == "Wall")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        }
        else if(gameObject.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        }
        else if (gameObject.tag == "Box")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        }
        else if (gameObject.tag == "Pad")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        }
        else if (gameObject.tag == "Bar")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        }
    }
}