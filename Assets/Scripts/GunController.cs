using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {
    //MOAR VARIABLES
	public GameObject toastBullet;
	public GameObject Gun;
	public float restTimer = 0;
    public Image cooldown;

	void Update () {
        //Is the mouse button down and rest set to zero?
		if (Input.GetMouseButtonDown (0) && restTimer <= 0) { //Spawn your bullet
			GameObject bulletSpawn = Instantiate (toastBullet, Gun.transform.position, Quaternion.identity);
			bulletSpawn.GetComponent<BulletScript>().Gun = gameObject;

            //Decide how long the bullet should rest
            if (PlayerPrefs.GetString("Weapon") == "Pistol")
            {
                restTimer = 60;
            } else if (PlayerPrefs.GetString("Weapon") == "Rifle")
            {
                restTimer = 120;
            }

		}

        //Give the cooldown meter it's length
        cooldown.fillAmount = restTimer / 100;
        Debug.Log("RestTimer: " + restTimer / 100);

	}

    private void FixedUpdate()
    { 
        //Only subtract the restTimer if it's greater than zero.
        if (restTimer > 0)
        {
            restTimer = restTimer - 1;
        }
    }
}