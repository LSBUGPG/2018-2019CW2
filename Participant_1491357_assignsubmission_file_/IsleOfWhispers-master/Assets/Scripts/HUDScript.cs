using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
    int ghostcount;
    float health;
    public Slider healthbar;
    public Text ghosttext;
    
    PlayerMovement playerscript;
	// Use this for initialization
	void Start () {
        playerscript = FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        healthbar.value = playerscript.health/100;
        ghostcount = FindObjectsOfType<GhostController>().Length;
        ghosttext.text = ghostcount.ToString();
	}
}
