using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player controls for on the field.
public class PlayerControl : MonoBehaviour
{
	public Vector2 speed = new Vector2(50, 50);

	private Vector2 adjustment;
	private Rigidbody2D rigidbodyComponent;
	SpriteRenderer sprRenderer;
	Animator Player;
	bool WalkIsTrue;

	void Start() {
		sprRenderer = GetComponent<SpriteRenderer> ();
		Player = gameObject.GetComponent<Animator> ();
		WalkIsTrue = false;
	}

	void Update() {

		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");

		if (Input.GetKey (KeyCode.A)) {
			sprRenderer.flipX = false;
		} else if (Input.GetKey (KeyCode.D)) {
			sprRenderer.flipX = true;
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) {
			WalkIsTrue = true;
		} else {
			WalkIsTrue = false;
		}

		if (WalkIsTrue == false) {
			Player.SetBool ("WalkIsTrue", false);
		} else if (WalkIsTrue == true) {
			Player.SetBool ("WalkIsTrue", true);
		}

		adjustment = new Vector2 (speed.x * horizontalInput, speed.y * verticalInput);

	}

	void FixedUpdate() {
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = adjustment;
	}
}