using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text countText;

    public int count = 0;

    // Use this for initialization
    void Start () {

        SetCountText();

    }
	
	// Update is called once per frame
	void Update () {
        SetCountText();

    }

    void SetCountText()
    {
        countText.text = "Essence: " + count.ToString() + "/5";
    }
}
