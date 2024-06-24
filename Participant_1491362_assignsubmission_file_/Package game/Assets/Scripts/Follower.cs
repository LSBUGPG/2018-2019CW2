using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
	public float speed;
	public Transform targetTransform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		follow ();
	}
	void follow(){
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		transform.LookAt (targetTransform);
}
}