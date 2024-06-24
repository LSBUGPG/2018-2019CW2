using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendNumber : MonoBehaviour {

    InputField inputField;

	void Start ()
    {
        inputField = GetComponent<InputField>();	
	}

    public void SendRoomCount()
    {
        if(inputField.text == null || int.Parse(inputField.text) == 0)
        {
            GameController.gameController.SetDungeonRoomCount(10);
        }
        GameController.gameController.SetDungeonRoomCount(int.Parse(inputField.text));
    }
}
