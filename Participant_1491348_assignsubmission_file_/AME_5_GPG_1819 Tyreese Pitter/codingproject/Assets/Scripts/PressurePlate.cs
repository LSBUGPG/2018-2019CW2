using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	public GameObject ObjToDestroy;
	public Timer timer;

	void OnTriggerEnter (Collider plyr) {
		Destroy (ObjToDestroy);
		timer.enabled = true;
	}
}