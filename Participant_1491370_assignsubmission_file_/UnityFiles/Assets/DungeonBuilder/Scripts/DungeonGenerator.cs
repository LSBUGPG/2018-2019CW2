using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour {

    public static DungeonGenerator dungeonGenerator;
    
    [Header("Dungeon Creation Variables")]
    public List<GameObject> dungeonRooms;
    public GameObject dungeonEndPiece;
    public GameObject startingRoom;
    public int maxRooms;
    public int dungeonRoomDistance;
    public Transform dungeonParent;

    [Header("DO NOT EDIT")]
    public int index;
    public List<GameObject> roomsInDungeon = new List<GameObject>();
    public bool finishedGeneration;
    int roomFilled = 0;
    float catchTimer;

    void Start ()
    {
        if(GameController.gameController != null)
        {
            maxRooms = GameController.gameController.GetDungeonRoomCount();
        }
        dungeonGenerator = this;
        roomsInDungeon.Add(startingRoom);
        startingRoom.GetComponent<DungeonRoom>().startingBlock = true;
        StartCoroutine(DungeonGeneration());
    }

    private void Update()
    {
        if(catchTimer > 0)
        {
            catchTimer -= 1 * Time.deltaTime;

            if(catchTimer < 0 && !finishedGeneration)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void SpawnRoom(int index)
    {
        if (roomsInDungeon[index].GetComponent<DungeonRoom>().useableSpawnPoints.Count > 0)
        {
            for (int i = 0; i < roomsInDungeon[index].GetComponent<DungeonRoom>().useableSpawnPoints.Count; i++)
            {
                GameObject newRoom = Instantiate(dungeonRooms[Random.Range(0, dungeonRooms.Count)], roomsInDungeon[index].GetComponent<DungeonRoom>().useableSpawnPoints[i]);
                newRoom.transform.SetParent(null);
                roomsInDungeon.Add(newRoom);
                newRoom.name = newRoom.name + roomsInDungeon.Count;
            }
        }
    }

    IEnumerator DungeonGeneration()
    {
        bool checkAgain = false;

        while (roomsInDungeon.Count < maxRooms && !checkAgain)
        {
            if (index >= 0)
            {
                SpawnRoom(index);

                yield return new WaitForSeconds(0.1f);

                List<GameObject> _roomsInDungeon = roomsInDungeon;

                if (_roomsInDungeon[index].GetComponent<DungeonRoom>().readyToSpawn)
                {
                    if (_roomsInDungeon[index].GetComponent<DungeonRoom>().finishedSpawning)
                    {
                        roomFilled = 0;
                        foreach (GameObject _room in _roomsInDungeon)
                        {
                            if (_room != null)
                            {
                                if (_room.GetComponent<DungeonRoom>().useableSpawnPoints.Count == 0)
                                {
                                    roomFilled++;
                                }
                            }
                        }

                        if (roomFilled < roomsInDungeon.Count)
                        {
                            index++;
                        }
                    }
                }

                if(_roomsInDungeon != roomsInDungeon)
                {
                    checkAgain = true;
                }

            }
            else
            {
                index = 0;
            }
        }

        while (roomFilled < roomsInDungeon.Count && !checkAgain)
        {
            roomFilled = 0;

            List<GameObject> _roomsInDungeon = roomsInDungeon;

            foreach (GameObject _room in _roomsInDungeon)
            {
                catchTimer += 0.3f;

                if (_room != null)
                {
                    _room.GetComponent<DungeonRoom>().FeedbackSpawnPoints();

                    if (_room.GetComponent<DungeonRoom>().useableSpawnPoints.Count > 0)
                    {
                        _room.GetComponent<DungeonRoom>().CreateFailsafePiece();
                    }
                    else
                    {
                        roomFilled++;
                    }
                }

                yield return new WaitForSeconds(0.2f);
            }

            if (_roomsInDungeon != roomsInDungeon)
            {
                checkAgain = true;
            }
        }

        foreach(GameObject room in roomsInDungeon)
        {
            room.GetComponent<DungeonRoom>().SetSpawnVisualOff();
            room.transform.SetParent(dungeonParent);
        }

        GenerateNavMesh.genNavMesh.GenMesh();

        finishedGeneration = true;
    }
}
