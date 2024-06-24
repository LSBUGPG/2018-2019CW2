using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {

    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

	// Use this for initialization
	void Start () {

        myAgent = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown (0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition); //for camera
            RaycastHit hitInfo;

            if (Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point); //actually moves the player
            }
        }
		
	}
}
