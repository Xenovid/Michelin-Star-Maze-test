using System;
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
        
    }
    void ClosedRoom()
    {
        int i;
        spawna = GameObject.FindGameObjectWithTag("Spawn Point").GetComponent<SpawnTemplates>();
        for (i = 0; i <= spawna.spawns.Count; i++)
        {
            if (spawna.spawns[i] != null)
            {
                if (openingDirection == 1)
                {
                    //Need spawn Bottom Door
                    
                    Instantiate(templates.closedRoom[1], transform.position, templates.closedRoom[1].transform.rotation);

                }
                else if (openingDirection == 2)
                {
                    //Need Top Door
                    
                    Instantiate(templates.closedRoom[2], transform.position, templates.closedRoom[2].transform.rotation);
                }
                else if (openingDirection == 3)
                {
                    //Need Left Door
                    
                    Instantiate(templates.closedRoom[4], transform.position, templates.closedRoom[3].transform.rotation);
                }
                else if (openingDirection == 4)
                { }
                    
                    Instantiate(templates.closedRoom[3], transform.position, templates.closedRoom[4].transform.rotation);
                
                spawned = true;
            }
        }
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
<<<<<<< Updated upstream
            

=======
            for (i = 0; i <= 5; i++) {
                rand = UnityEngine.Random.Range(0, 1000);
                rand1 = UnityEngine.Random.Range(0, 1000);
                Instantiate(items.foodobjs[0], new Vector3 (rand, 1, rand1), Quaternion.identity);
            }
>>>>>>> Stashed changes
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
                

            }
            spawned = true;
            
        }
        Invoke("ClosedRoom", 4.0f);

    }
    
}
