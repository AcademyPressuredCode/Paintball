using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public GameObject toastBullet;
	public GameObject Gun;
	public int restTimer;

	void Update () {
		
		if (Input.GetMouseButtonDown (0) && restTimer == 0) {
			GameObject bulletSpawn = Instantiate (toastBullet, Gun.transform.position, Quaternion.identity);
			bulletSpawn.GetComponent<BulletScript>().Gun = gameObject;
		}

	}
}