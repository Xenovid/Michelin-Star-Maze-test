using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    
    int i;
    int j;
    int rand;

    void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.newrooms.Add(this.gameObject);
    }


    void Start() {
        
    }

    

    
}

