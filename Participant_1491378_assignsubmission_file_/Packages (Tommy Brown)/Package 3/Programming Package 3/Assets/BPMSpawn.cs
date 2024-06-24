using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMSpawn : MonoBehaviour
{
	public List<Transform> spawnPos = new List<Transform>();
    public GameObject[] projectiles;
    public float spawnSpeed;
    //private float lastTime, deltaTime, timer;

	bool run = true;

    void Start()
    {
		foreach(Transform child in transform)
		{
			spawnPos.Add (child);
		}
		StartCoroutine (spawnRate()); //Start Couroutine for spaning objects with the beat
//        lastTime = 0f;
//        deltaTime = 0f;
//        timer = 0f;
    }


    void Update()
    {
//        int rand = Random.Range(0, 3);
//        deltaTime = GetComponent<AudioSource>().time - lastTime;
//        timer += deltaTime;
//
//        if (timer >= (60f / bpm))
//        {
//            ((GameObject)Instantiate(notePrefab, posStart[rand].transform.position, posStart[rand].transform.rotation)).GetComponent<Transform>().parent = GetComponent<Transform>();
//            timer = 0f;
//        }
//
//        lastTime = GetComponent<AudioSource>().time;
    }

	IEnumerator spawnRate()
	{
		float wait = 60f / spawnSpeed; // calculate time delay between spawns
//		float adjustedWait = wait - 0.01f;
//		float totalOutSync = 0f;
//		int count = 0;

		while (run) 
		{
            int prefabs = Random.Range(0, projectiles.Length);
			int spawner = Random.Range(0, spawnPos.Count);
			((GameObject)Instantiate(projectiles[prefabs], spawnPos[spawner])).GetComponent<Transform>().SetParent(transform);

//			float time1 = Time.time;
            
			yield return new WaitForSeconds (wait); // wait for time between spawning, then loop back to top of while

//			count++;
//			float elapsedTime = Time.time - time1;
//			float dTime = elapsedTime - wait;
//			totalOutSync += dTime;
//
//			Debug.Log ("Time Elapsed: " +  elapsedTime.ToString());
//			Debug.Log ("Delta Time: " + dTime.ToString());
//			Debug.Log ("AVG out sync: " + (totalOutSync / count));
//			Debug.Log ("BEAT");
		}

	}
}