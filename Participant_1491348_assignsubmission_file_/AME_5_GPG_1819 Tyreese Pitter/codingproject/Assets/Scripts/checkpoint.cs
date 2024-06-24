using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {
	
	public static int checkpoints = 0;
	public Timer timer;


	// Use this for initialization
	void Awake () {
		checkpoints++;

	}

	private void OnTriggerEnter(Collider plyr)
	{
		if (plyr.gameObject.tag== "Player")
		{
			Respawn respawn = plyr.GetComponent<Respawn> ();
			if (respawn != null) {
				respawn.currentCheckpoint = transform.position;
			}

			checkpoints--;
			gameObject.SetActive(false);
			timer.timeLeft = 20;
		}
	}
}
