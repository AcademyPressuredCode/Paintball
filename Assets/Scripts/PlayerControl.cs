using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player controls for on the field.
public class PlayerControl : MonoBehaviour
{
	public Vector2 speed = new Vector2(50, 50);

	Vector2 PlayerPos;
	private Vector2 adjustment;
	private Rigidbody2D rigidbodyComponent;
	SpriteRenderer sprRenderer;


	void Start() {
		sprRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update() {
        //Find Mouse Position
        Vector2 mousePos = Input.mousePosition;
		Vector2 AB = mousePos - PlayerPos;

		//Find the angle from the player position in Radians
		float angle = Mathf.Atan2 (AB.y, AB.x);

		//Adjust to Degrees
		float deg = angle * Mathf.Rad2Deg;
		Debug.Log ("Radians: " + angle + " Degree: " + deg);

		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
	
		adjustment = new Vector2 (speed.x * horizontalInput, speed.y * verticalInput);

	}

	void FixedUpdate() {
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = adjustment;
	}
}