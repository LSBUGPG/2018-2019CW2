using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyCalculations : MonoBehaviour { //use this one, it works, mostly
	//Variables
	private static int pounds1 = 0; //top left calculations
	private static int shillings1 = 0;
	private static int pence1 = 0;
	public Text poundsText1;
	public Text shillingsText1; 
	public Text penceText1; 
	public Text totalText1;
	//private static int totalPounds1 = 0; //old - was accidently creating a whole new variable for nothing when I could have used pounds1 & pounds2 variables to use in calculations
	//private static int totalShillings1 = 0;
	//private static int totalPence1 = 0;

	//Variables 2
	private static int pounds2 = 0; //top right calculations
	private static int shillings2 = 0;
	private static int pence2 = 0;
	public Text poundsText2;  
	public Text shillingsText2; 
	public Text penceText2; 
	public Text totalText2;
	//private static int totalPounds2 = 0;
	//private static int totalShillings2 = 0;
	//private static int totalPence2 = 0;

	//Variables 3
	private static int pounds3 = 0; //bottom left calculations
	private static int shillings3 = 0;
	private static int pence3 = 0;
	public Text poundsText3;  
	public Text shillingsText3; 
	public Text penceText3; 
	public Text totalText3;
	//private static int totalPounds3 = 0;
	//private static int totalShillings3 = 0;
	//private static int totalPence3 = 0;

	//Variables 4
	private static int pounds4 = 0; //bottom right calculations
	private static int shillings4 = 0;
	private static int pence4 = 0;
	public Text poundsText4;  
	public Text shillingsText4; 
	public Text penceText4; 
	public Text totalText4;
	//private static int totalPounds4 = 0;
	//private static int totalShillings4 = 0;
	//private static int totalPence4 = 0;

	//Variables 5 & 6
	public Text totalText5;
	//public static int topHalfTotal = 0;
	public Text totalText6;
	//public static int bottomHalfTotal = 0;

	//Variables 7
	//private double total1 = 0;
	private static int totalPoundsTopHalf = 0;
	private static int totalShillingsTopHalf = 0;
	private static int totalPenceTopHalf = 0;

	private static int totalPoundsTopHalf2 = 0;
	private static int totalShillingsTopHalf2 = 0;
	private static int totalPenceTopHalf2 = 0;

	//private static int totalPoundsBottomHalf = 0;
	//private static int totalShillingsBottomHalf = 0;
	//private static int totalPenceBottomHalf = 0;

	//private static int totalPoundsBottomHalf2 = 0;
	//private static int totalShillingsBottomHalf2 = 0;
	//private static int totalPenceBottomHalf2 = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//top left text boxes 
		poundsText1.text = "Pounds: " + pounds1; //whats displayed in the text box
		shillingsText1.text = "Shillings: " + shillings1; 
		penceText1.text = "Pence: " + pence1; 
		totalText1.text = "Total Money: " + "£" + pounds1 + "." + shillings1 + "." + pence1;
		//total1 = pounds + shillings + pence;

		//top right text boxes 
		poundsText2.text = "Pounds: " + pounds2; 
		shillingsText2.text = "Shillings: " + shillings2; 
		penceText2.text = "Pence: " + pence2; 
		totalText2.text = "Total Money: " + "£" + pounds2 + "." + shillings2 + "." + pence2;
		//total2 = pounds2 + shillings2 + pence2;

		//bottom left text boxes 
		poundsText3.text = "Pounds: " + pounds3; 
		shillingsText3.text = "Shillings: " + shillings3; 
		penceText3.text = "Pence: " + pence3; 
		totalText3.text = "Total Money: " + "£" + pounds3 + "." + shillings3 + "." + pence3;

		//bottom right text boxes 
		poundsText4.text = "Pounds: " + pounds4; 
		shillingsText4.text = "Shillings: " + shillings4; 
		penceText4.text = "Pence: " + pence4; 
		totalText4.text = "Total Money: " + "£" + pounds4 + "." + shillings4 + "." + pence4;

		//top half totals //calculates the total for the top half
		totalPoundsTopHalf = pounds1 + pounds2; //old - totalPoundsTopHalf = totalPounds1 + totalPounds2;
		totalShillingsTopHalf = shillings1 + shillings2;
		totalPenceTopHalf = pence1 + pence2;

		totalPoundsTopHalf2 = pounds1 - pounds2; //old - totalPoundsTopHalf = totalPounds1 + totalPounds2;
		totalShillingsTopHalf2 = shillings1 - shillings2;
		totalPenceTopHalf2 = pence1 - pence2;

		//bottom half totals //calculates the total for the bottom half
		//totalPoundsBottomHalf = pounds3 + pounds4;
		//totalShillingsBottomHalf = shillings3 + shillings4;
		//totalPenceBottomHalf = pence3 + pence4;

		//totalPoundsBottomHalf2 = pounds3 + pounds4;
		//totalShillingsBottomHalf2 = shillings3 + shillings4;
		//totalPenceBottomHalf2 = pence3 + pence4; 


		//12 pence in a shilling //240 pence in a pound
		//20 shillings in a pound
		if (shillings1 >= 20) {
			pounds1 += 1;
			shillings1 = 0;
		}
		if (pence1 >= 12) {
			shillings1 += 1;
			pence1 = 0;
		}
		if (shillings2 >= 20) {
			pounds2 += 1;
			shillings2 = 0;
		}
		if (pence2 >= 12) {
			shillings2 += 1;
			pence2 = 0;
		}
		if (shillings3 >= 20) {
			pounds2 += 1;
			shillings2 = 0;
		}
		if (pence3 >= 12) {
			shillings3 += 1;
			pence3 = 0;
		}
		if (shillings4 >= 20) {
			pounds4 += 1;
			shillings4 = 0;
		}
		if (pence4 >= 12) {
			shillings4 += 1;
			pence4 = 0;
		}
		if (totalShillingsTopHalf >= 20) {
			totalPoundsTopHalf += 1;
			totalShillingsTopHalf  = 0;
		}
		if (totalPenceTopHalf >= 12) {
			totalShillingsTopHalf += 1;
			totalPenceTopHalf = 0;
		}
			
	}


	//top left button functions
	public void ButtonPlusOnePound () {
		pounds1 += 1;
	}
	public void ButtonPlusOneShilling () {
		shillings1 += 1;
	}
	public void ButtonPlusOnePence () {
		pence1 += 1;
	}
		
	//top right button functions
	public void ButtonPlusOnePound2 () {
		pounds2 += 1;
	}
	public void ButtonPlusOneShilling2 () {
		shillings2 += 1;
	}
	public void ButtonPlusOnePence2 () {
		pence2 += 1;
	}

	//bottom left button functions
	public void ButtonPlusOnePound3 () {
		pounds3 += 1;
	}
	public void ButtonPlusOneShilling3 () {
		shillings3 += 1;
	}
	public void ButtonPlusOnePence3 () {
		pence3 += 1;
	}

	//bottom right button functions
	public void ButtonPlusOnePound4 () {
		pounds4 += 1;
	}
	public void ButtonPlusOneShilling4 () {
		shillings4 += 1;
	}
	public void ButtonPlusOnePence4 () {
		pence4 += 1;
	}

	//top half plus & minus total
	public void PlusTotal () { //top half total
		//total += total2 = topHalfTotal;
		//totalText5.text = "Total: £ " + topHalfTotal;

		//total1 = total1 + double.Parse (totalText5.text);
		//totalText5.Clear ();

		//topHalfTotal = totalText.text + totalText2.text;
		//topHalfTotal = total1 + total2;
		//totalText5.text = "Total: " + topHalfTotal;

		//totalText5.text = "Total: " + pounds + shillings + pence + pounds2 + shillings2 + pence2;

		//totalText5.text = "Total: " + totalPoundsTopHalf + "-" + totalShillingsTopHalf + "-" + totalPenceTopHalf.ToString();
		totalText5.text = "Total: " + totalPoundsTopHalf + "." + totalShillingsTopHalf + "." + totalPenceTopHalf;
	}
	public void MinusTotal () { //bottom half total
		//total -= total2 = bottomHalfTotal;
		//totalText6.text = "Total: £ " + topHalfTotal;

		//topHalfTotal = total1 - total2;
		//totalText5.text = "Total: " + topHalfTotal;

		//totalText5.text = ""; //clears the text box
		totalText5.text = "Total: " + totalPoundsTopHalf2 + "." + totalShillingsTopHalf2 + "." + totalPenceTopHalf2;

		//if (totalPoundsTopHalf2 <= 0) {
			//totalPoundsTopHalf2 = totalPoundsTopHalf2 * -1; //to set number as minus

		//} else {

			//totalText5.text = "Total: " + totalPoundsTopHalf2 + "-" + totalShillingsTopHalf2 + "-" + totalPenceTopHalf2;
		//}
	} //myInt = my Int * -1 //to set number as minus

	//bottom half equal to & greater than & less than total
	public void EqualToTotal () {
		
		if (pounds3 == pounds4 && shillings3 == shillings4 && pence3 == pence4) {
			totalText6.text = "Left & Right totals are equal to each other";
		} else {
			totalText6.text = "Left & Right totals are not equal to each other";
		}
	}

	public void GreaterThanTotal () {
		
		//if (pounds3 > pounds4 && shillings3 > shillings4 && pence3 > pence4) { //small issue as it needs all 3 pounds, shillings & pence to be greater than right side
			//totalText6.text = "Left total is greater than Right total";
		//} else {
			//totalText6.text = "Left total is not greater than Right total";
		//}

		if (pounds3 > pounds4 || (pounds3 == pounds4 && shillings3 > shillings4) || (pounds3 == pounds4 && shillings3 == shillings4 && pence3 > pence4)) {
			totalText6.text = "Left total is greater than Right total";
		} else {
			totalText6.text = "Left total is not greater than Right total";
		}
	}

	public void LessThanTotal () {
		
		//if (pounds3 < pounds4 && shillings3 < shillings4 && pence3 < pence4) { //small issue as it needs all 3 pounds, shillings & pence to be less than right side
			//totalText6.text = "Left total is less than Right total";
		//} else {
			//totalText6.text = "Left total is not less than Right total";
		//}

		if (pounds3 < pounds4 || (pounds3 == pounds4 && shillings3 < shillings4) || (pounds3 == pounds4 && shillings3 == shillings4 && pence3 < pence4)) {
			totalText6.text = "Left total is less than Right total";
		} else {
			totalText6.text = "Left total is not less than Right total";
		}
	}
}
