using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

	public GameObject toastBullet;
	public GameObject Gun;
	public float restTimer = 0;
    public Image cooldown;

	void Update () {

		if (Input.GetMouseButtonDown (0) && restTimer == 0) {
			GameObject bulletSpawn = Instantiate (toastBullet, Gun.transform.position, Quaternion.identity);
			bulletSpawn.GetComponent<BulletScript>().Gun = gameObject;

            if (PlayerPrefs.GetString("Weapon") == "Pistol")
            {
                restTimer = 60;
            } else if (PlayerPrefs.GetString("Weapon") == "Rifle")
            {
                restTimer = 120;
            }

		}

        cooldown.fillAmount = restTimer / 100;
        Debug.Log("RestTimer: " + restTimer / 100);

	}

    private void FixedUpdate()
    {
        if (restTimer > 0)
        {
            restTimer = restTimer - 1;
        }
    }
}