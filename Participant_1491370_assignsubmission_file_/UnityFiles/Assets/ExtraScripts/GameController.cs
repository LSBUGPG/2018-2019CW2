using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameController;
    int dungeonRoomCount;

	void Start ()
    {
		if(gameController != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameController = this;
            DontDestroyOnLoad(gameController);
        }
	}
	
	public void SetDungeonRoomCount(int i)
    {
        dungeonRoomCount = i;
    }

    public int GetDungeonRoomCount()
    {
        return dungeonRoomCount;
    }
}
