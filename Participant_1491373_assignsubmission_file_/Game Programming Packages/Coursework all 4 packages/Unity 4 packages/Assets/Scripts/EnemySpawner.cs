using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;
	public int xPos;
	public int zPos;
	public int enemyCount;

	// Use this for initialization
	void Start () {
		StartCoroutine (EnemyDrop ());
	}

	IEnumerator EnemyDrop() {

		while (enemyCount < 10) {
			xPos = Random.Range (-32, -20);
			zPos = Random.Range (-12, 14);
			Instantiate (Enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
			yield return new WaitForSeconds (3f);
			enemyCount += 1;
		}

	}

}
