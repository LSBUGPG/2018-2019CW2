using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<NavMeshAgent> ().SetDestination(Player.transform.position);

	}
}
