using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use UI

public class Currency : MonoBehaviour { //for £sd currency //adds money to the corresponding values

	private int pounds = 0;
	private int shillings = 0;
	private int pence = 0;

	public Text poundsText; //to display in a text box 
	public Text shillingsText; //to display in a text box 
	public Text penceText; //to display in a text box 

	//private int totalMoney = 0; //old
	public Text totalText;

	// Use this for initialization
	void Start () {
		//Game scene requires a canvas and 2 text boxes. After attatching this script to the canvas attach a text boxe to all the text slots while looking at this script in the inspector.
	}
	
	// Update is called once per frame
	void Update () {
		poundsText.text = "Pounds: " + pounds; //whats displayed in the text box
		shillingsText.text = "Shillings: " + shillings; //whats displayed in the text box
		penceText.text = "Pence: " + pence; //whats displayed in the text box


		totalText.text = "Total Money: " + "£" + pounds + "-" + shillings + "-" + pence; //whats displayed in the text box



		if (Input.GetKeyDown(KeyCode.Q)) { //replace these 3 if statements with what you need to add money e.g. collisions
			pounds += 1;
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			shillings += 1;
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			pence += 1;
		}
			


		//12 pence in a shilling //240 pence in a pound
		//20 shillings in a pound
		if (shillings >= 20) {
			pounds += 1;
			shillings = 0;
		}
		if (pence >= 12) {
			shillings += 1;
			pence = 0;
		}

	}
}
