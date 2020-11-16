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
        templates.Tables[0].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        rand = UnityEngine.Random.Range(0, templates.newrooms.Count);
        Instantiate(templates.Tables[1], new Vector3(templates.newrooms[rand].transform.position.x, 1.5f, templates.newrooms[rand].transform.position.z), templates.Tables[1].transform.rotation);

        for (i = 0; i < 6; i++)
        {
            rand = UnityEngine.Random.Range(0, templates.newrooms.Count);
            Instantiate(templates.Tables[0], new Vector3(templates.newrooms[rand].transform.position.x, 1.5f, templates.newrooms[rand].transform.position.z), templates.Tables[0].transform.rotation);
        }
        

        for (i = 0; i < templates.newrooms.Count; i++)
        {
            for (j = 0; j < 5; j++)
            {
                UnityEngine.Random.seed = UnityEngine.Random.Range(0, 100);
                rand = UnityEngine.Random.Range(0, templates.newrooms.Count);
                Instantiate(templates.Foods[i], new Vector3(templates.newrooms[rand].transform.position.x+2, 1.7f, templates.newrooms[rand].transform.position.z-2), templates.Foods[0].transform.rotation);
            }
        }
        
    }

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnItems", 1.0f);
    }
}
