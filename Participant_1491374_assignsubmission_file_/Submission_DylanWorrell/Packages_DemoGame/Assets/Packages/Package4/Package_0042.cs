using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package_0042 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, 2);
	}

	// Update is called once per frame
	void Update ()
	{
		//explosion grows bigger
		transform.localScale += new Vector3 (5, 5, 5) * Time.deltaTime;
	}
}
