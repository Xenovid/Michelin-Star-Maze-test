﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> Need Bottom Door
    // 2 --> Need Top Door
    // 3 --> Need Left Door
    // 4 --> Need Right Door


    private RoomTemplates templates;
    private SpawnTemplates spawna;
    
    private int rand;
    private int rand1;
    private int rand2;
    int i;
    private bool spawned = false;
    public GameObject spawn;
    


    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
        Invoke("Spawn", 0.1f);
        Invoke("ClosedRooms", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //Need spawn Bottom Door
                rand = UnityEngine.Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);

            }
            else if (openingDirection == 2)
            {
                //Need Top Door
                rand = UnityEngine.Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Need Left Door
                rand = UnityEngine.Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Need Rigth Door
                rand = UnityEngine.Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
            

        }
        
        

    }
    void ClosedRooms()
    {
        if (GameObject.FindGameObjectWithTag("Spawn Point") != null && spawned == false)
        {

            Instantiate(templates.closedRoom[0], spawna.spawns[1].transform.position, templates.closedRoom[0].transform.rotation);
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Spawn Point") && otherCollider.CompareTag("Spawn Point") != null)
        {
            if (otherCollider.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //GameObject go = GameObject.FindGameObjectWithTag("Rooms");
                Destroy(gameObject);
                Invoke("ClosedRooms", 0.1f);

            }
            spawned = true;
            
        }
       

    }
    
}
