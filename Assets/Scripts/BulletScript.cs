using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public float lifetime;
	public float speed = 50f;
	public GameObject Gun;

    private string cachedWeapon;
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

    void recieveWeaponType (string Weapon)
    {
        cachedWeapon = Weapon;
        Debug.Log(Weapon);
    }

    void Start () {
		
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