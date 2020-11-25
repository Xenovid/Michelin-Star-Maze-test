using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpawn : MonoBehaviour
{
    private SpawnTemplates spawna;
    

    void Start()
    {
        spawna = GameObject.Find("Spawn Templates").GetComponent<SpawnTemplates>();
        spawna.spawns.Add(this.gameObject);

        

        
    }

    
}
