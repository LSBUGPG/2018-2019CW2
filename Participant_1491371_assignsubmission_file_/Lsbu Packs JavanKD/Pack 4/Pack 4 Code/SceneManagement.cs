using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider", gameObject);
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("PartTwo", LoadSceneMode.Single);
        }
    }
}