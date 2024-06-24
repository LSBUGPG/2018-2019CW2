    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public static EnemyController enemyController;
    public List<GameObject> enemyTypesList;

    public GameObject player;
    public List<Enemy> enemyList;

    bool purging;

	void Start ()
    {
        enemyController = this;

        AddEnemiesToList();
	}

    private void Update()
    {
        if (enemyList.Contains(null) && !purging)
        {
            PurgeList();   
        }
    }

    public void AddEnemiesToList()
    {
        Enemy[] _enemies = FindObjectsOfType<Enemy>();
        if (_enemies.Length > 0)
        {
            foreach (Enemy e in _enemies)
            {
                if (!enemyList.Contains(e))
                {
                    enemyList.Add(e);
                }
            }
        }
    }

    public void SpawnEnemy(Vector3 spawnPos, int enemyType)
    {
        GameObject _enemy = Instantiate(enemyTypesList[enemyType], spawnPos, enemyTypesList[enemyType].transform.rotation);
        _enemy.transform.SetParent(null);
        _enemy.transform.eulerAngles += new Vector3(0, Random.Range(0, 360), 0);
        AddEnemiesToList();
    }

    public void PurgeList()
    {
        purging = true;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if(enemyList[i] == null)
            {
                enemyList.Remove(enemyList[i]);
                i--;
            }
        }
        purging = false;
    }
}
