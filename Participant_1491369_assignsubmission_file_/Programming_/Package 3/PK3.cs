using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// SPIKES/RESPAWN

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) // If a game object with the "Player" tag enters the collider...
        {
            Scene scene = SceneManager.GetActiveScene(); // SceneManager finds the current active scene...

            SceneManager.LoadScene(scene.name); // ...and loads in the current scene.
        }
    }
}
