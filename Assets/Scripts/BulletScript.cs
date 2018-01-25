using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public float lifetime;
	public float speed = 50f;
	public GameObject Gun;
	private Vector2 bulletDir = Vector2.zero;


    void OnCollisionEnter2D(Collision2D col)
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