using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
   private int apples = 0;
   private int chicken = 0;
   private int broccoli = 0;
   private int oil = 0;
   private int onion = 0;
   private int tables = 0;

   public foodCounter FC;

    private void Start()
    {
        apples = 0;
        chicken = 0;
        broccoli = 0;
        oil = 0;
        onion = 0;
        tables = 0;
    }

    public void addItem(string itemName){
        FindObjectOfType<audioManager>().play("collect");
        if (itemName == "apple"){
           apples++;
           FC.changeApple(apples);
       }
       else if(itemName == "chicken"){
            chicken++;
            FC.changeChicken(chicken);
       }
       else if(itemName == "broccoli"){
           broccoli++;
           FC.changeBroccoli(broccoli);
       }
       else if(itemName == "oil")
        {
            oil++;
            FC.changeOil(oil);
        }
       else if(itemName == "onion")
        {
            onion++;
            FC.changeOnion(onion);
        }
        else if(itemName == "table")
        {
            tables++;
            FC.changeTable(tables);
        }
   }
   public int getApples(){
       return apples;
   }
   public int getChicken(){
       return chicken;
   }
    public int getBroccoli()
    {
        return broccoli;
    }
    public int getOil()
    {
        return oil;
    }
    public int getOnion()
    {
        return onion;
    }
}
