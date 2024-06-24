using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour {

    public string loadLevel;

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(loadLevel);
    }
}
