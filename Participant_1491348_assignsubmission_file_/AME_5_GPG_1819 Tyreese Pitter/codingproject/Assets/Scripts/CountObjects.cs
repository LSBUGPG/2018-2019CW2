using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountObjects : MonoBehaviour {
	
	public string nextLevel;

	GameObject objUI;
	public checkpoint checkpoint;
	// Use this for initialization
	void Start()
	{
		objUI = GameObject.Find("ObjectNum");
	}
	// Update is called once per frame
	void Update () {
		objUI.GetComponent<Text>().text = checkpoint.checkpoints.ToString();
		if (checkpoint.checkpoints == 0)
		{
			SceneManager.LoadScene ("EndGame");


		}

	}
}