using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Still trying to figure out how to setup variables at the beginning. Only one variable is set here so far.
public class VariableSet : MonoBehaviour {

    public void SetWeaponType(string WeaponName)
    {
        PlayerPrefs.SetString("Weapon", WeaponName);
        Debug.Log(PlayerPrefs.GetString("Weapon").ToString());
    }



    
}
