﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	private double lifetime;
	private float speed;
    private Vector2 bulletDir = Vector2.zero;

    public GameObject Gun;

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

		// Calculate the bullet direction
		bulletDir = (mousePos - (Vector2)Gun.transform.position);



	}
	void Update () {
		if (bulletDir != Vector2.zero)
			transform.Translate (bulletDir.normalized * speed * Time.deltaTime);

			lifetime -= Time.deltaTime;

			if (lifetime <= 0) {
				Destroy(gameObject);
			}
			

	}
}