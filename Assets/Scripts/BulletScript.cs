using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    //How many variables do you think I can fit in one script?
	private double lifetime;
	private float speed;
    private Vector2 bulletDir = Vector2.zero;
    public GameObject Gun;


    //Trigger stuff. Basically remove the bullet / player if it comes into contact with either. In the case of an enemy, it destroys both.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != null)
        {
            Debug.Log(col.gameObject);
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            } 
            if (col.gameObject.tag == "Wall")
            {
                Destroy(this.gameObject);
            }
        }
    }

    //Decide some stats based on the PlayerPreference that tells you the weapon.
    void Start () {

        if (PlayerPrefs.HasKey("Weapon") == false)
        {
            PlayerPrefs.SetString("Weapon", "Pistol");
        }

        if (PlayerPrefs.GetString("Weapon") == "Pistol")
        {
            speed = 14f;
        }
        else if (PlayerPrefs.GetString("Weapon") == "Rifle")
        {
            speed = 25f;
        }

        if (PlayerPrefs.GetString("Weapon") == "Pistol")
        {
            lifetime = 0.5;
        } else if (PlayerPrefs.GetString("Weapon") == "Rifle")
        {
            lifetime = 1.5;
        }

        Debug.Log(PlayerPrefs.GetString("Weapon").ToString());
        
        // Get the current mouse position
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Calculate the bullet direction (THIS IS BROKEN, FIX LATER)
		bulletDir = (mousePos - (Vector2)Gun.transform.position);



	} 
    //I barely know what's going on here so good luck
	void Update () {
		if (bulletDir != Vector2.zero)
			transform.Translate (bulletDir.normalized * speed * Time.deltaTime);

			lifetime -= Time.deltaTime;

			if (lifetime <= 0) {
				Destroy(gameObject);
			}
			

	}
}