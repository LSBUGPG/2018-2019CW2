using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public int timeLeft = 5;
	public Text countdownText;
	public CharacterController characterController;

	// Use this for initialization
	void Start()
	{
	}

	void OnEnable()
	{
		countdownText.enabled = true;
		StartCoroutine("LoseTime");
	}

	// Update is called once per frame
	void Update()
	{
		countdownText.text = ("Time Left = " + timeLeft);

		if (timeLeft <= 0)
		{
			StopCoroutine("LoseTime");
			countdownText.text = "Out Of Time ";
			SceneManager.LoadScene (3);

		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}

	}

}