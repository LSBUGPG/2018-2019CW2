using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDelete : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject,2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localScale += new Vector3 (80, 80, 80) * Time.deltaTime;
	}
}
