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
	Animator anim;

	bool WalkIsTrue;

	void Start() {
		sprRenderer = GetComponent<SpriteRenderer> ();
		anim = gameObject.GetComponent<Animator> ();
		WalkIsTrue = false;
	}

	void Update() {

		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		if (Input.GetKeyDown ("a")) {
			sprRenderer.flipX = false;
			WalkIsTrue = true;
		} else if (Input.GetKeyDown ("d")) {
			sprRenderer.flipX = true;
			WalkIsTrue = true;
		} else {
			WalkIsTrue = false;
		}

		if (WalkIsTrue == false) {
			anim.SetBool ("WalkIsTrue", false);
		} else if (WalkIsTrue == true) {
			anim.SetBool ("WalkIsTrue", true);
		}

		adjustment = new Vector2(speed.x * horizontalInput, speed.y * verticalInput);
	}

	void FixedUpdate() {
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = adjustment;
	}
}