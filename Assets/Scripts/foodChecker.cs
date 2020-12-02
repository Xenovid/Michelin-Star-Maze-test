using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodChecker : MonoBehaviour
{
    
    public messageSystem mesSys;
    public Timer tim;
    public GameObject RB;

    public int requiredApples;
    public int requiredChicken;
    public int requiredBroccoli;
    public int requiredOil;
    public int requiredOnion;

    public int requiredTables;



    public float timeLimit;
    private bool isCollectingFood = true;

    public bool getIscollectingFood()
    {
        return isCollectingFood;
    }


    private void Start() {
        isCollectingFood = true;
    }
    public void startCollecting(){
        tim.startTimer(timeLimit);
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("object entered");
        if (isCollectingFood){
            if (other.tag == "player"){
                GameObject play = other.gameObject;
                Collector col = play.GetComponent<Collector>();
                if ((col.getApples() >= requiredApples) && (col.getChicken() >= requiredChicken) && (col.getBroccoli() >= requiredBroccoli) && (col.getOil() >= requiredOil) && (col.getOnion() >= requiredOnion)){
                    mesSys.displayMessage("You Collected all the Items, now you need to serve your Customers!");
                    isCollectingFood = false;
                    foodCounter fc = FindObjectOfType<foodCounter>();
                    fc.activateTableCount();
                }
            }
        }
    }

    public void timerFinished(){
        Time.timeScale = 0.0f;
        RB.SetActive(true);
    }
    public void checkTableCount(int num)
    {
        if(num >= requiredTables && !isCollectingFood)
        {
            Time.timeScale = 0f;
            Text txt = RB.transform.Find("Text").GetComponent<Text>();

            if(txt == null)
            {
                Debug.Log("not found");
            }
            txt.text = "finished! Click to go to Main Menu";
            RB.SetActive(true);
            tim.stopTimer();
        }
    }
}
