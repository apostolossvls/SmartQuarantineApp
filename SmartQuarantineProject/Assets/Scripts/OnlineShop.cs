using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineShop : MonoBehaviour
{
    public GameObject diplay;
    public bool isOn;

    void Start(){
        isOn = !isOn;
        SetDisplay();
    }
    
    public void SetDisplay(){
        isOn = !isOn;
        if (isOn) {
            //OpenPanel(0);
        }
        diplay.SetActive(isOn);
    }

    public void SetDisplay(bool newIsOn){
        isOn = !newIsOn;
        SetDisplay();
    }
}
