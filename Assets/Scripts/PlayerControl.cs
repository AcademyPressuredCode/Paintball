using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player controls for on the field.
public class PlayerControl : MonoBehaviour
{   // ALL THE VARIABLES, PRIVATE *AND* PUBLIC
    public GameObject GUI;
    public Vector2 speed = new Vector2(50, 50);
    public Animator anim;
    private Vector2 adjustment;
	private Rigidbody2D rigidbodyComponent;
    private bool GUIon;
    public SpriteRenderer Player;


    void Update() {
        //Define movement with proper keys. 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Take movement, throw it into your speed.x/y
        adjustment = new Vector2(speed.x * horizontalInput, speed.y * verticalInput);

        //Activate the GUI
        if (Input.GetKeyUp(KeyCode.Escape)) {
            GUI.SetActive(!GUI.activeSelf);
        }

        //This bit decides whether or not to flip the character, and to play the running animation. It looks ugly atm, fixing later
        if (Input.GetKey(KeyCode.A))
        {
            Player.flipX = true;
            anim.SetBool("Walking", true);
        } else if (Input.GetKey(KeyCode.D)) {
            Player.flipX = false;
            anim.SetBool("Walking", true);
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walking", true);
        } else
        {
            anim.SetBool("Walking", false);
        }

    }
    //Stuff I barely understand, I'm pretty dumb. I think it moves it around or something.
	void FixedUpdate() {
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = adjustment;
	}
}