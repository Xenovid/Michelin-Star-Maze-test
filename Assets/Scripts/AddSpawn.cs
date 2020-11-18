using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpawn : MonoBehaviour
{
    private SpawnTemplates spawna;
    private RoomTemplates templates;

    void Start()
    {
        spawna = GameObject.FindGameObjectWithTag("Spawn Point").GetComponent<SpawnTemplates>();
        spawna.spawns.Add(this.gameObject);

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        
    }

    
}
