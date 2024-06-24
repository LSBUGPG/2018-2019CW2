using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

Animator plateAnim;
public string pressureParam;

	// Use this for initialization
	void Start () 
	{
		plateAnim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter ()
	{
		plateAnim.SetTrigger(pressureParam);
		GameManager.instance.OpenDoor();
	}
}
