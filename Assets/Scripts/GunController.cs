using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public GameObject bullet;
	public Transform Player;
	public int restTimer;

	void Update () {
		
		if (Input.GetMouseButtonDown (0) && restTimer == 0) {
			GameObject bulletSpawn = Instantiate (bullet, Player.position, Quaternion.identity);
			bulletSpawn.GetComponent<BulletScript>().Player = gameObject;
		}

	}
}