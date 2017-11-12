using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float speed = 25f;
	public GameObject Gun;
	private Vector2 bulletDir = Vector2.zero;


	void Start () {
		
		// Get the current mouse position
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Calculate the bullet direction
		bulletDir = (mousePos - (Vector2)Gun.transform.position);

	}
	void Update () {
		if (bulletDir != Vector2.zero)
			transform.Translate (bulletDir * speed * Time.deltaTime);
	}

}
