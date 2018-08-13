using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    private GameObject _player;
    public GameObject Player { get { return _player; } set { _player = value; } }

	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (null == _player)
        {
            return;
        }

		float posX = Mathf.SmoothDamp (transform.position.x, _player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, _player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}
