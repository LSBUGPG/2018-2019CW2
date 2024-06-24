using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoom : MonoBehaviour {

    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<Transform> useableSpawnPoints = new List<Transform>();

	public List<GameObject> backupPieces;

    public List<GameObject> connectingRooms;

    public bool startingBlock, justSpawned;
    public bool readyToSpawn, finishedSpawning;
    bool nextCheck;

	public LayerMask roomCheckMask;

	public GameObject failSafePiece;

	public int connectingDoors;
	public int spinChecks, failCount;
    int triggerChecks;
    int checkDistance;

    void Start ()
    {
        transform.GetChild(0).GetChild(0).gameObject.layer = 10;
        checkDistance = DungeonGenerator.dungeonGenerator.dungeonRoomDistance;

        foreach (Transform child in transform.GetChild(1))
        {
            spawnPoints.Add(child.gameObject);
        }

        SetSpawnPointPositions();
        TriggerFeedback();

        if (startingBlock)
        {
            readyToSpawn = true;
        }
	}
	
	void FixedUpdate ()
    {
        if (!readyToSpawn && nextCheck)
        {
			if (CheckSurroundingRooms())
            {
                readyToSpawn = true;
            }
        }

        if (readyToSpawn && !finishedSpawning)
        {

            FeedbackSpawnPoints();

            if (useableSpawnPoints.Count == 0)
            {
                finishedSpawning = true;
            }
        }

		if (spinChecks > DungeonGenerator.dungeonGenerator.maxRooms * 2) 
		{
			CreateBackupPiece ();
		}
	}

    [ContextMenu("Check Spawn Points")]
    public void FeedbackSpawnPoints()
    {
		roomCheckMask = LayerMask.GetMask ("DungeonRooms");

		for (int i = 0; i < spawnPoints.Count; i++) 
		{
			RaycastHit hit;

			if (Physics.Raycast (spawnPoints [i].transform.position + new Vector3(0,5,0), Vector3.down, out hit, 3f, roomCheckMask)) 
			{
				if (useableSpawnPoints.Contains (spawnPoints [i].transform)) 
				{
					useableSpawnPoints.Remove(spawnPoints[i].transform);
				}
			} 
			else 
			{
				if (!useableSpawnPoints.Contains (spawnPoints [i].transform)) 
				{
					useableSpawnPoints.Add (spawnPoints [i].transform);
				}
			}
		}
    }

	bool CheckSurroundingRooms()
	{
        //print("beginning " + gameObject.name);
        if (connectingRooms.Count == 0)
        {
            TriggerFeedback();
            triggerChecks++;
            if(triggerChecks > DungeonGenerator.dungeonGenerator.maxRooms)
            {
                CreateFailsafePiece();
            }
            return false;
        }
        //print("got through " + gameObject.name);

		roomCheckMask = LayerMask.GetMask ("DungeonRooms");
		nextCheck = false;
        int foundRooms = 0;
        bool foundBadRoom = false;

		for (int i = 0; i < spawnPoints.Count; i++) 
		{
			RaycastHit hit;

			Debug.DrawRay(spawnPoints [i].transform.position,Vector3.up * 2f, Color.red);

			if (Physics.Raycast (spawnPoints [i].transform.position + new Vector3(0,5,0), Vector3.down, out hit, 2f, roomCheckMask)) 
			{
                for (int o = 0; o < connectingRooms.Count; o++)
                {
                    if (hit.collider.gameObject.transform.root.gameObject == connectingRooms[o])
                    {
                        foundRooms++;
                        foundBadRoom = false;
                        break;
                    }
                    else
                    {
                        foundBadRoom = true;
                    }
                }

                if (foundBadRoom)
                {
                    RotateObject();
                    return false;
                }
			}

		}

        if(foundRooms == connectingDoors)
        {
            return true;
        }
        RotateObject();
        return false;
	}

    void RotateObject()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
		nextCheck = true;
		spinChecks++;
    }

	void TriggerFeedback()
	{
		roomCheckMask = LayerMask.GetMask ("DungeonRooms");

		for (int i = 0; i < 4; i++) 
		{
			float rotation = i * 90;
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, rotation, transform.eulerAngles.z);

			Debug.DrawRay((transform.position + (transform.forward * checkDistance)) + new Vector3 (0, 5, 0),Vector3.down * 3f, Color.blue);

			RaycastHit hit;

			if (Physics.Raycast ((transform.position + (transform.forward * checkDistance)) + new Vector3 (0, 5, 0), Vector3.down, out hit, 3f, roomCheckMask)) 
			{
				if(hit.collider.transform.root.gameObject.GetComponent<DungeonRoom>() != null)
                {
                    hit.transform.root.gameObject.GetComponent<DungeonRoom>().OutputFeedback(gameObject);
                }
			}
		}

		transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range (1, 5) * 90, transform.eulerAngles.z);

        nextCheck = true;
	}

	public void OutputFeedback(GameObject targetPiece)
	{
		for (int i = 0; i < spawnPoints.Count; i++) 
		{
			RaycastHit hit;

			Debug.DrawRay(spawnPoints [i].transform.position,Vector3.up * 5f, Color.green);

			if (Physics.Raycast (spawnPoints [i].transform.position + new Vector3(0,5,0), Vector3.down, out hit, 3f, roomCheckMask)) 
			{
				if (hit.collider.gameObject.transform.root.gameObject == targetPiece) 
				{
					targetPiece.GetComponent<DungeonRoom> ().connectingDoors++;
                    if (!targetPiece.GetComponent<DungeonRoom>().connectingRooms.Contains(gameObject))
                    {
                        targetPiece.GetComponent<DungeonRoom>().connectingRooms.Add(gameObject);
                    }
				}
			} 
		}
	}

	public void CreateBackupPiece()
	{
        if(failCount > 0)
        {
            if (connectingDoors != 2)
            {
                CreateFailsafePiece();
                return;
            }
            else
            {
                if (failCount > 1)
                {
                    CreateFailsafePiece();
                    return;
                }
            }
        }

        GameObject newPiece = null;

        if (connectingDoors - 1 >= 0 && connectingDoors - 1 < backupPieces.Count)
        {
            if(connectingDoors == 2)
            {
                if(failCount == 0)
                {
                    newPiece = Instantiate(backupPieces[0], transform);
                }
                else
                {
                    newPiece = Instantiate(backupPieces[1], transform);
                }
            }
            else
            {
                newPiece = Instantiate(backupPieces[connectingDoors - 1], transform);
            }
        }
        else
        {
            newPiece = Instantiate(failSafePiece, transform);
        }
        if (newPiece != null)
        {
            newPiece.transform.SetParent(null);
            newPiece.GetComponent<DungeonRoom>().failCount++;
            if (DungeonGenerator.dungeonGenerator.roomsInDungeon.Contains(gameObject))
            {
                DungeonGenerator.dungeonGenerator.roomsInDungeon[DungeonGenerator.dungeonGenerator.roomsInDungeon.IndexOf(gameObject)] = newPiece;
            }
            Destroy(gameObject);
        }
	}
    public void CreateFailsafePiece()
    {
        if(failCount >= 3)
        {
            DungeonGenerator.dungeonGenerator.index = 0;
            DungeonGenerator.dungeonGenerator.roomsInDungeon.Remove(gameObject);
            Destroy(gameObject);
        }
        failCount++;
        GameObject newPiece = Instantiate(failSafePiece, transform);
        newPiece.transform.SetParent(null);
        if (DungeonGenerator.dungeonGenerator.roomsInDungeon.Contains(gameObject))
        {
            DungeonGenerator.dungeonGenerator.roomsInDungeon[DungeonGenerator.dungeonGenerator.roomsInDungeon.IndexOf(gameObject)] = newPiece;
        }
        Destroy(gameObject);
    }

    public void SetSpawnPointPositions()
    {
        foreach (GameObject spawn in spawnPoints)
        {
            spawn.transform.localPosition *= checkDistance;
        }
    }

    public void SetSpawnVisualOff()
    {
        foreach(GameObject spawn in spawnPoints)
        {
            spawn.SetActive(false);
        }
    }
}
