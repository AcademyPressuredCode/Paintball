using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player controls for on the field.
public class PlayerControl : MonoBehaviour
{
    public GameObject GUI;
    public Vector2 speed = new Vector2(50, 50);

    private Vector2 adjustment;
	private Rigidbody2D rigidbodyComponent;
    private bool GUIon;
    public SpriteRenderer Player;
    

	void Update() {
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
	
		adjustment = new Vector2 (speed.x * horizontalInput, speed.y * verticalInput);

        if (Input.GetKeyUp(KeyCode.Escape)) {
            GUI.SetActive(!GUI.activeSelf);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Player.flipX = true;
        } else if (Input.GetKey(KeyCode.D)){
            Player.flipX = false;
        }

    }

	void FixedUpdate() {
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = adjustment;
	}
}