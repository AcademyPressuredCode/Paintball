using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	private float lifetime;
	private float speed;

    public GameObject Gun;
    public string WeaponType;

	private Vector2 bulletDir = Vector2.zero;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != null)
        {
            Debug.Log(col.gameObject);
            if (col.gameObject.tag == "Player")
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
            lifetime = 1;
        } else if (PlayerPrefs.GetString("Weapon") == "Rifle")
        {
            lifetime = 2;
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