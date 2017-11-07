using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public GameObject bullet;
	public Transform Player;
	public int restTimer;

	void Update () {
		
		if (Input.GetMouseButtonDown (0) && restTimer == 0) {
			Instantiate (bullet, Player.position, Player.rotation);
		}

	}
}