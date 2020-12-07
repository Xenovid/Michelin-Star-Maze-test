using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    public foodChecker fc;
    void Update()
    {
        if(fc.getIsloaded()){
            gameObject.SetActive(false);
        }
    }
}
