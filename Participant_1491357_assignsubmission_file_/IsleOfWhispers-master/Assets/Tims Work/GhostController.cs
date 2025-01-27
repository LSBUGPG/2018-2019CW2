﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [Tooltip("The ghosts speed in m/s"), Range(0, .4f)] public float speed = 0.05f;
    [Tooltip("The ghosts vertical speed in m/s"), Range(0, 1f)] public float vSpeed = 0.5f;
    [Tooltip("The time between ghost shots")] public float shotCooldown = 2f;
    [Tooltip("The range of the ghost will detect the player")] public float detectionRange = 30f;
    [Tooltip("The time in seconds the ghost waits to change directions"), Range(0, 1)] public float changetime = .1f;
    [Tooltip("The chance that a ghost will change direction, higher values makes it less likely"), Range(0, 10)] public int chanceChange = 5;
    [Tooltip("The 'time' required before a ghost will switch turning direction, higher values increase the 'time'"), Range(0, 10)] public int switchTime = 5;
    [Tooltip("The minimum height in meters that a ghost can fly up")] public float minHeight = 1f;
    [Tooltip("The maximum height in meters that a ghost can fly up")] public float maxHeight = 4f;
    [Tooltip("The minimum angle in degrees which the ghost can turn each change")] public float minAngle = 5f;
    [Tooltip("The maximum angle in degrees which the ghost can turn each change")] public float maxAngle = 30f;

    int liveChance;
    float targetHeight;
    float count = 5;
    bool inRange = false;
    Vector3 deltaH;
    public bool isvisible = false;
    Renderer rend;
    public GameObject ghostshot;
    public float shot_speed = 300;

    void Start()
    {
        liveChance = chanceChange;
        StartCoroutine(changeDirection());
        StartCoroutine(checkFire());
        targetHeight = transform.position.y;
        tarHeightChange(targetHeight);
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isvisible)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
        Vector3 dir = transform.forward.normalized;
        float y = transform.position.y;

        if(y > targetHeight && deltaH.y > 0)
        {   tarHeightChange(y); }
        else if(y < targetHeight && deltaH.y < 0)
        {   tarHeightChange(y); }

        dir += deltaH;
        transform.Translate(dir * speed);

        Debug.LogFormat("count = {0} inRange = {1}, isvisible= {2}", count, inRange, isvisible);
        if (count <= 0 && inRange && isvisible)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform);
            Debug.Log("in range");
            fireShot();
            count = shotCooldown;
        }
        else if (count > 0)
        {   count -= Time.deltaTime;    }
    }

    IEnumerator changeDirection()
    {
        int c = 0;
        float LR = 1;

        while (true)
        {
            int i = (int)Random.Range(0, 10);
            c += i;
            
            if (c * 10 >  switchTime * 10)
            {   LR = -LR;   c = 0;  }

            if (i < liveChance)
            {
                Vector3 angChange = new Vector3(0, Random.Range(minAngle, maxAngle) * LR, 0);
                angChange += transform.localEulerAngles;
                transform.localRotation = Quaternion.Euler(angChange);
            }

            yield return new WaitForSeconds(changetime);
        }
    }

    IEnumerator checkFire()
    {
        while(true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float distance = Vector3.Distance(player.transform.position, transform.position);
            inRange = (distance < detectionRange);
           //Vector3 dir = player.transform.position - transform.position;
           // RaycastHit hit;

           // Debug.DrawRay(transform.position + transform.forward, dir);
           // if(Physics.Raycast(transform.position + transform.forward, dir, out hit, detectionRange))
           // {
           //     if(hit.transform.tag == "Player")
           //     {   inRange = true; }
           //     else
           //     {   inRange = false;    }
           // }

            yield return new WaitForSeconds(.1f);
        }
    }

    void tarHeightChange(float f)
    {
        targetHeight = Random.Range(minHeight, maxHeight);

        if (targetHeight > f)
        {   deltaH = new Vector3(0, vSpeed, 0); }
        else
        {   deltaH = new Vector3(0, -vSpeed, 0);    }
    }

    void fireShot()
    {
        Debug.Log("Shoot");
        GameObject instGhost = Instantiate(ghostshot, transform.position, Quaternion.identity) as GameObject;
        Rigidbody instLightRB = instGhost.GetComponent<Rigidbody>();
        instLightRB.AddForce((transform.forward) * shot_speed, ForceMode.Impulse);
    }
}
