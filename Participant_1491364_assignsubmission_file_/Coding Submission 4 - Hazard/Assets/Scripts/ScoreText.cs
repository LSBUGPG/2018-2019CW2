using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //NEEDED TO USE UI!
// REMEMBER: Attach script to character not UI element!!!!

public class ScoreText : MonoBehaviour {

	Text Score;
	public int ScoreUp = 0;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = FindObjectOfType<PlayerController>();
        Score = Text.FindObjectOfType<Text> ();

	}

	// Update is called once per frame
	void Update () {
        ScoreUp = playerController.collectablesCollected;
        Score.text = "Score: " + ScoreUp.ToString();
    }
}
