using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	public void PlayGame() 
	{
		SceneManager.LoadScene (1);
	}
	public void EndGame ()
	{
		Application.Quit ();
	}
}
