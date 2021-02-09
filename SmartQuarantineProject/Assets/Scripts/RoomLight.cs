using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    public Light roomLight;

    public void SetLight(bool isOn){
        roomLight.enabled = isOn;
    }
}
