using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour {

    public static GenerateEnemies genEnemies;
    int roomCheck;

	void Start ()
    {
        genEnemies = this;
	}
	
	public void GenEnemies()
    {
        foreach(GameObject room in DungeonGenerator.dungeonGenerator.roomsInDungeon)
        {
            if (roomCheck == 0)
            {
                roomCheck++;
            }
            else
            {
                int random = Random.Range(0, 2);

                if (random != 0)
                {
                    EnemyController.enemyController.SpawnEnemy(room.transform.position, 0);
                }
            }
        }

        LevelController.levelController.StartGame();
    }
}
