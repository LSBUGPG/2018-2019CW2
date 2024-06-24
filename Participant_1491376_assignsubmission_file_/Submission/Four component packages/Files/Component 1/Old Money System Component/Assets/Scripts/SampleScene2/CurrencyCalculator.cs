using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyCalculator : MonoBehaviour { //The calculator runs on a 3 point decimal system for the money e.g. £3.11.05 //not finished, couldnt figure out how to save value and use second

	//private static int pounds;
	//private static float shillings;
	//private static decimal pence; //static variable to be shared between all instances of the script //float instead of int to use decimals

	//public static float total;
	public Text totalText;

	private static float amount;

	// Use this for initialization
	void Start () {
		//pounds = 0;
		//shillings = 0;
		//pence = 0;
		//total = 0;

		//amount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//totalText.text = "Total: " + "£" + pounds + "-" + shillings + "-" + pence; //whats displayed in the text box
		//total = pounds + shillings + pence;
		//totalText.text = "Total:" + total;

		totalText.text = "Total:" + amount;


		//12 pence in a shilling //240 pence in a pound
		//20 shillings in a pound
		/*if (shillings >= 20) {
			pounds += 1;
			shillings = 0;
		}
		if (pence >= 12) {
			shillings += 1;
			pence = 0;
		}
	*/}

	public void Button1 () {
		amount += 1;
		//Debug.Log ("+1");
	}
	public void Button2 () {
		amount += 2;
		//Debug.Log ("+2");
	}
	public void Button3 () {
		amount += 3;
		//Debug.Log ("+3");
	}
	public void Button4 () {
		amount += 4;
		//Debug.Log ("+4");
	}
	public void Button5 () {
		amount += 5;
		//Debug.Log ("+5");
	}
	public void Button6 () {
		amount += 6;
		//Debug.Log ("+6");
	}
	public void Button7 () {
		amount += 7;
		//Debug.Log ("+7");
	}
	public void Button8 () {
		amount += 8;
		//Debug.Log ("+8");
	}
	public void Button9 () {
		amount += 9;
		//Debug.Log ("+9");
	}
	public void Button0 () {

		Debug.Log ("+0");
	}
	public void ButtonPlus () {
		//String add = (Convert.ToInt32 (totalText.text) + 2).ToString ();
		//save current number, allow player to input new number
	}
	public void ButtonMinus () {

	}
	public void ButtonPoint () {
		//1.1.1
	}
	public void ButtonEquals () {
		//total = A + B
	}
	public void ButtonClear () {
		//pounds = 0;
		//shillings = 0;
		//pence = 0;
		//total = 0;
		amount = 0;
		Debug.Log ("Cleared");
	}
}
//int number = 1000000000;
//string whatYouWant = number.ToString("#, ##0");
//You get 1,000,000,000

//String add = (myTextBox.Text + 2);