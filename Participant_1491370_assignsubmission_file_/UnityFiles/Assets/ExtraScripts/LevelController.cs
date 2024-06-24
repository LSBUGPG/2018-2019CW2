using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public static LevelController levelController;
    public MenuController menuController;
    public GameObject player, loadingScreen, loadingCam;
    bool gameStart;

    public Text enemyCount;

    void Start ()
    {
        menuController.enabled = false;
        levelController = this;
        player.SetActive(false);
    }

    void Update()
    {
        if (gameStart)
        {
            enemyCount.text = "Enemies remaining: " + EnemyController.enemyController.enemyList.Count;

            if(EnemyController.enemyController.enemyList.Count == 0)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
	
	public void StartGame()
    {
        player.SetActive(true);
        loadingScreen.SetActive(false);
        Destroy(loadingCam);
        enemyCount.gameObject.SetActive(true);
        menuController.enabled = true;
        gameStart = true;
    }
}
