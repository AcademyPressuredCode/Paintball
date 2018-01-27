using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    static public string Weapon = "pistol";

	public void LoadUnityScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

    private void Start()
    {
        Messenger.Broadcast<string>("Weapon Type", Weapon);
    }
}
