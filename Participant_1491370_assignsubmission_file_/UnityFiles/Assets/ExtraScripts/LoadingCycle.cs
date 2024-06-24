using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCycle : MonoBehaviour {

    Text loadingText;
    public string[] loadingList;
    float timer;
    int index;

	void Start ()
    {
        loadingText = GetComponent<Text>();
	}
	
	void Update ()
    {
		if(timer <= Time.time)
        {
            timer = 0.25f + Time.time;
            loadingText.text = loadingList[index];
            index++;
            if(index >= loadingList.Length)
            {
                index = 0;
            }
        }
	}
}
