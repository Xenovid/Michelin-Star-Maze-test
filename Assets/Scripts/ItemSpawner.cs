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
        int z = 0;
        templates.Tables[0].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        rand = (templates.newrooms.Count - 1);
        //the food checker has a bunch on items that it needs to know(and arn't connected in the prefab), just inisilizing it will break the game
        //Instantiate(templates.Tables[1], new Vector3(templates.newrooms[rand].transform.position.x, 1.5f, templates.newrooms[rand].transform.position.z), templates.Tables[1].transform.rotation);
        templates.newrooms.RemoveAt(rand);
        for (i = 0; i < 6; i++)
        {
            rand = UnityEngine.Random.Range(0, templates.newrooms.Count);
            Instantiate(templates.Tables[0], new Vector3(templates.newrooms[rand].transform.position.x, 1.5f, templates.newrooms[rand].transform.position.z), templates.Tables[0].transform.rotation);
        }
        

        for (i = 0; i < templates.newrooms.Count; i++)
        {
            z++;
            if (z == 100)
            {
                Debug.Log("wayyyyyyyy to much");
                break;
            }
            //changed to 2 since there is currently only 2 foods implemented
            for (j = 0; j < 2; j++)
            {
                UnityEngine.Random.seed = UnityEngine.Random.Range(0, 100);
                rand = UnityEngine.Random.Range(0, templates.newrooms.Count-1);
                Instantiate(templates.Foods[j], new Vector3(templates.newrooms[rand].transform.position.x+2, 1.7f, templates.newrooms[rand].transform.position.z-2), templates.Foods[0].transform.rotation);
                Instantiate(templates.Lights[0], new Vector3(templates.newrooms[rand].transform.position.x + 2, 12f, templates.newrooms[rand].transform.position.z - 2), templates.Lights[0].transform.rotation);
            }
        }
        
    }

    

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnItems", 2.0f);
        
    }
}
