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
    private ItemTemplate items;
    private int rand;
    private int rand1;
    int i;
    private bool spawned = false;


    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        items = GameObject.FindGameObjectWithTag("Foods").GetComponent<ItemTemplate>();
        Invoke("Spawn", 0.1f);
        
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
            //for (i = 0; i <= 5; i++) {
               // rand = UnityEngine.Random.Range(0, 1000);
               // rand1 = UnityEngine.Random.Range(0, 1000);
               // Instantiate(items.foodobjs[0], new Vector3 (rand, 1, rand1), new Vector3(0,0,0));
            //}
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Spawn Point"))
        {
            Destroy(gameObject);
        }
    }
}
