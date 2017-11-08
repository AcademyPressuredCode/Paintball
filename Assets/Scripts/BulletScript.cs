using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float speed = 50f;
	public GameObject Player;
	private Vector2 bulletDir = Vector2.zero;


	void Start () {
		
		// Get the current mouse position
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Calculate the bullet direction
		bulletDir = ((Vector2)Player.transform.position - mousePos).normalized;


	}

	void Update () {
		if (bulletDir != Vector2.zero)
			transform.Translate (bulletDir * speed * Time.deltaTime);
	}

}
