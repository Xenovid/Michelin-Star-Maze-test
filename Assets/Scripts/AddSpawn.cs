﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpawn : MonoBehaviour
{
    public SpawnTemplates spawna;
    

    void Start()
    {
        spawna = GameObject.Find("Spawn Templates").GetComponent<SpawnTemplates>();
        spawna.spawns.Add(this.gameObject);

        Invoke("Add", 4.0f);
    }

    void Add() {
        spawna = GameObject.Find("Spawn Templates").GetComponent<SpawnTemplates>();
        spawna.spawns.Add(this.gameObject);
    }
    
}
