using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public RoomLight[] lights;
    public bool isOn;
    public bool lightsOn;
    bool lightsOnLast;

    void Start(){
        lightsOnLast = lightsOn;
        SetLights(lightsOn);
    }


    void Update()
    {
        if (lightsOn != lightsOnLast){
            lightsOnLast = lightsOn;
            SetLights(lightsOn);
        }
    }

    //toggle lights
    public void SetLights(){
        isOn = !isOn;
        if (lights.Length > 0){
            foreach (RoomLight light in lights)
            {
                light.SetLight(isOn);
            }
        }
    }

    //set isOn to opposite of newIsOn so on SetLights isOn = newIsOn
    public void SetLights(bool newIsOn){
        isOn = !newIsOn;
        SetLights();
    }
}
