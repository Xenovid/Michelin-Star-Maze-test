using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    
    int i;
    int j;
    int rand;

    public void SpawnItems()
    {
        
        for (j = 0; j <= 5; j++)
        {
            rand = UnityEngine.Random.Range(0, templates.newrooms.Count);
            Instantiate(templates.Foods[1], templates.newrooms[rand].transform.position, templates.Foods[0].transform.rotation);
        }
    }

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        SpawnItems();
    }
}
