using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

    NavMeshAgent nma;

    GameObject player;
    public Vector3 lastKnownLocale, spawnPosition;
    public float speed, panSpeed, panDist, visionLength, visionWidth, trackTime, pauseTime;
    float panMin, panMax, panDir;
    float trackTimer, pauseTimer;
    float panning;

    public LayerMask visionMask;
    bool trackingPlayer;
    bool canSeePlayer;
    bool searching;

	void Start ()
    {
        nma = GetComponent<NavMeshAgent>();
        player = EnemyController.enemyController.player;
        spawnPosition = transform.position;
        panDir = 1;
        SetPanning();
	}
	
	void Update ()
    {
        if (trackingPlayer)
        {
            if (canSeePlayer)
            {
                trackTimer = trackTime;
                SetTarget(player.transform.position);
            }
            else
            {
                if (!searching)
                {
                    SetTarget(lastKnownLocale);

                    if(nma.remainingDistance < 0.4f)
                    {
                        searching = true;
                        pauseTimer = pauseTime;
                        GenerateLastLocale(lastKnownLocale);
                        SetTarget(lastKnownLocale);
                    }
                }
                else
                {
                    pauseTimer -= 1 * Time.deltaTime;
                    if(pauseTimer <= 0)
                    {
                        searching = true;
                    }
                }
            }

            trackTimer -= Time.deltaTime * 1;
            CheckPlayer();

            if(trackTimer <= 0)
            {
                trackingPlayer = false;
            }
        }
        else
        {
            VisionCone();

            if (Vector3.Distance(transform.position, spawnPosition) > 0.9f)
            {
                SetTarget(spawnPosition);
                SetPanning();
            }
            else if(Vector3.Distance(transform.position, spawnPosition) <= 0.9f)
            {
                print("panning");
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, panning, transform.eulerAngles.z);

                if(panning >= panMax)
                {
                    panDir = -1;
                }
                else if(panning <= panMin)
                {
                    panDir = 1;
                }

                panning += (panSpeed * panDir) * Time.deltaTime;
            }
        }
	}

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    void SetPanning()
    {
        panning = transform.eulerAngles.y;
        panMin = panning - (panDist / 2);
        panMax = panning + (panDist / 2);
    }

    void SetTarget(Vector3 target)
    {
        nma.destination = target;
    }

    void CheckPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, visionLength, visionMask))
        {
            if (hit.collider.tag == "Player")
            {
                canSeePlayer = true;
                if (!trackingPlayer)
                {
                    trackingPlayer = true;
                }
            }
            else
            {
                if (canSeePlayer)
                {
                    GenerateLastLocale(player.transform.position);
                    canSeePlayer = false;
                }
            }
        }
        else
        {
            if (canSeePlayer)
            {
                GenerateLastLocale(player.transform.position);
                canSeePlayer = false;
            }
        }
    }

    void GenerateLastLocale(Vector3 pos)
    {
        lastKnownLocale = pos + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
    }

    void VisionCone()
    {
        for (int i = -Mathf.RoundToInt(visionWidth) * 10; i < Mathf.RoundToInt(visionWidth) * 20; i++)
        {
            Vector3 distancePoint = transform.position + ((transform.forward * visionLength) + (transform.right * i/10));
            Vector3 direction = (distancePoint - transform.position).normalized;
            RaycastHit hit;

            Debug.DrawRay(transform.position + Vector3.up, direction * visionLength, Color.red);

            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit, visionLength, visionMask))
            {
                if (hit.collider.tag == "Player")
                {
                    canSeePlayer = true;
                    if (!trackingPlayer)
                    {
                        trackingPlayer = true;
                        trackTimer = trackTime;
                    }
                    break;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        
    }
}
