using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		Respawn respawn = collider.GetComponent<Respawn> ();
		if (respawn != null) {
			respawn.DoRespawn ();
		}
	}
}
