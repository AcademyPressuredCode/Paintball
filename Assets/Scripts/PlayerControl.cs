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
    

	void Update() {
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
	
		adjustment = new Vector2 (speed.x * horizontalInput, speed.y * verticalInput);

        if (Input.GetKeyUp(Keycode.Escape)
{
            GUI.SetActive(!GUI.activeSelf);
        }
    }

	void FixedUpdate() {
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = adjustment;
	}
}