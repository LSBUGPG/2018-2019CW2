using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// COIN PICKUP

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals ("Player")){ // If the a gameObject with the tag Player enters the collider...
            Score.scoreValue += 1; // ...the score value on our Score script is increased by 1 and...
            Destroy(gameObject); // ...the coin object is destroyed!
        }
    }
}
