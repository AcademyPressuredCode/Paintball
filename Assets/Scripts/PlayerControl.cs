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


	void Update() {
        //Find Mouse Position
        Vector2 mousePos = Input.mousePosition;

        //Find the angle from the player position in Radians
        float angle = Vector2.Angle(PlayerPos, mousePos);

		//Adjust to Degrees
		float deg = angle * Mathf.Rad2Deg;
        Debug.Log("Angle??: " + angle);

		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
	
		adjustment = new Vector2 (speed.x * horizontalInput, speed.y * verticalInput);

	}

	void FixedUpdate() {
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = adjustment;
	}
}