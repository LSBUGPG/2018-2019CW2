using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject Canvas;
	public GameObject Camera;
	bool Paused = false;
	public AudioSource GameMusic;

	// Use this for initialization
	void Start () {
		Canvas.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Paused == true) {
				//Debug.Log ("Unpause game!", gameObject);
				Time.timeScale = 1.0f;
				Canvas.gameObject.SetActive (false);
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				GameMusic.UnPause();
				Paused = false;

			} else {
				//Debug.Log ("Pause game!", gameObject);
				Time.timeScale = 0.0f;
				Canvas.gameObject.SetActive (true);
				//Debug.LogFormat ("Pause Menu is {0}", Canvas.gameObject.activeSelf);
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				GameMusic.Pause ();
				Paused = true;

			}
		}
	}

	public void Resume () {
		Time.timeScale = 1.0f;
		Canvas.gameObject.SetActive (false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		GameMusic.UnPause();
		Paused = false;
	}
}

