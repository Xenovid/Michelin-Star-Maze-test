using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFunction : MonoBehaviour
{
    public string itemName;
    private bool isTablePhase;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && isTablePhase)
        {
            GameObject play = other.gameObject;
            Debug.Log(play.name);
            Collector col = play.GetComponent<Collector>();
            if (col != null)
            {
                col.addItem(itemName);
                Collider collid = gameObject.GetComponent<Collider>();
                collid.enabled = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTablePhase)
        {
            foodChecker fc = FindObjectOfType<foodChecker>();
            fc.getIscollectingFood();
            if (!fc.getIscollectingFood())
            {
                isTablePhase = true;
            }
        }
    }
}