using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    public bool matchesCollected;
    public bool createFireAllowed;
    public GameObject createFireText;
    public GameObject getLogsText;

    public Player charCon;
    public Pickingup pickup;

    // Use this for initialization
    void Start () {
        createFireText.SetActive(false);
        getLogsText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {


        if (matchesCollected && createFireAllowed && Input.GetKeyDown(KeyCode.Space))
        {
            makeFire();
        }

	}

    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.name.Equals("Player") && matchesCollected)
        {
            createFireAllowed = true;
            createFireText.SetActive(true);
        }
        else
        {
            getLogsText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision )
    {
        if (collision.gameObject.name.Equals("Player") )
        {
            createFireAllowed = false;
            createFireText.SetActive(false);
            getLogsText.SetActive(false);
        }
    }


    void makeFire()
    {
        charCon.count += 1;
        pickup.matchesText.gameObject.SetActive(false);
        matchesCollected = false;
        createFireAllowed = false;
        createFireText.SetActive(false);
    }
}
