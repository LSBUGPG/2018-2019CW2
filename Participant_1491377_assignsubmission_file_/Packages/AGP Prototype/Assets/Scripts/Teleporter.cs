using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public GameObject destination;
	public float teleportTime = 0.5f;
	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		StartCoroutine ("Teleport", other.gameObject);
	}
	
	IEnumerator Teleport (GameObject teleported)
	{
		teleported.SetActive(false);
		yield return new WaitForSeconds (teleportTime);
		teleported.transform.position = destination.transform.position;
		teleported.SetActive(true);
	}
}
