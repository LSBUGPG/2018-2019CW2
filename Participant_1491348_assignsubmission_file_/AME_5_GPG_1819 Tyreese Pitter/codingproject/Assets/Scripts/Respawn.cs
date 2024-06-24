﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public Vector3 currentCheckpoint;

	void Start()
	{
		currentCheckpoint = transform.position;
	}

	public void DoRespawn()
	{
		transform.position = currentCheckpoint;
	}
}
