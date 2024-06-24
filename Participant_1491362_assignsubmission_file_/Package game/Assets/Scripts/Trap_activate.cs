using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_activate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider wall){
	
		if (wall.gameObject.tag == "Player") {
			StartCoroutine (Example ());
		}
		
	
	}

	IEnumerator Example()
	{
		print(Time.time);
		yield return new WaitForSeconds(0);
		gameObject.SetActive (false);
	}
}

